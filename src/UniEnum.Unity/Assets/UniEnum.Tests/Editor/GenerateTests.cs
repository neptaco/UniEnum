using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using UniEnumUtils.SourceGenerator;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace UniEnumEditorTests
{
    public class GenerateTests
    {
        [Test]
        public void IdentifierTest()
        {
            Assert.AreEqual("hoge", "hoge".SanitizeForIdentifier());
            Assert.AreEqual("_01234", "01234".SanitizeForIdentifier());
            Assert.AreEqual("あいうえお", "あいうえお".SanitizeForIdentifier());
            Assert.AreEqual("_123abcWXZ11", "!@#$%^&*()[]'/123 abcWXZ-11".SanitizeForIdentifier());
        }

        [Test]
        public void ModifierTest()
        {
            var sb = new StringBuilder();

            sb.Length = 0;
            sb.AppendVariableDeclareModifier(Modifier.Const);
            Assert.AreEqual("const ", sb.ToString());
            
            sb.Length = 0;
            sb.AppendVariableDeclareModifier(Modifier.Static);
            Assert.AreEqual("static ", sb.ToString());
            
            sb.Length = 0;
            sb.AppendVariableDeclareModifier(Modifier.Readonly);
            Assert.AreEqual("readonly ", sb.ToString());
            
            sb.Length = 0;
            sb.AppendVariableDeclareModifier(Modifier.Readonly | Modifier.Static);
            Assert.AreEqual("static readonly ", sb.ToString());
            
        }

        [Test]
        public void IndentTest()
        {
            var indent = new IndentState();
            Assert.AreEqual("", indent.ToString());

            indent.Indent += 1;
            Assert.AreEqual(1, indent.Indent);
            Assert.AreEqual("    ", indent.ToString());
            
            indent.Indent += 1;
            Assert.AreEqual(2, indent.Indent);
            Assert.AreEqual("        ", indent.ToString());
            
            indent.Indent -= 1;
            Assert.AreEqual(1, indent.Indent);
            Assert.AreEqual("    ", indent.ToString());
            
            indent.Indent -= 1;
            Assert.AreEqual(0, indent.Indent);
            Assert.AreEqual("", indent.ToString());
            
            indent.Indent -= 1;
            Assert.AreEqual(0, indent.Indent);
            Assert.AreEqual("", indent.ToString());
            
        }

        [UnityTest]
        public IEnumerator SceneTest()
        {
            const string basePath = "Assets/UniEnum.Tests/Editor/Scenes";

            var sceneFiles = Directory.EnumerateFiles(basePath, "*.unity", SearchOption.AllDirectories)
                .Select(v => new EditorBuildSettingsScene(v, true))
                .ToArray();

            var setting = new GenerateSetting()
            {
                Namespace = "UniEnumEditorTests",
                OutputDir = "Assets/UniEnum.Tests/Editor/TestOutput",
            };
            
            AssetDatabase.DeleteAsset($"{setting.OutputDir}/SceneValues.Generated.cs");
            
            UnityConstantValuesGenerator.UpdateSceneValues(setting, sceneFiles);

            yield return new RecompileScripts();

            Assert.AreEqual("UniEnumTest_100", SceneName.UniEnumTest_100);
            Assert.AreEqual("UniEnumTest_101", SceneName.UniEnumTest_101);
            Assert.AreEqual("UniEnumTest_102", SceneName.UniEnumTest_102);

            Assert.AreEqual(0, SceneId.UniEnumTest_100);
            Assert.AreEqual(1, SceneId.UniEnumTest_101);
            Assert.AreEqual(2, SceneId.UniEnumTest_102);

            Assert.AreEqual($"{basePath}/UniEnumTest_100.unity", ScenePath.UniEnumTest_100);
            Assert.AreEqual($"{basePath}/UniEnumTest_101.unity", ScenePath.UniEnumTest_101);
            Assert.AreEqual($"{basePath}/UniEnumTest_102.unity", ScenePath.UniEnumTest_102);

        }
        
        [UnityTest]
        public IEnumerator UnityConstantsTest()
        {
            var setting = new GenerateSetting()
            {
                Namespace = "UniEnumEditorTests",
                OutputDir = "Assets/UniEnum.Tests/Editor/TestOutput",
            };
            
            AssetDatabase.DeleteAsset($"{setting.OutputDir}/TagValues.Generated.cs");
            AssetDatabase.DeleteAsset($"{setting.OutputDir}/LayerValues.Generated.cs");
            AssetDatabase.DeleteAsset($"{setting.OutputDir}/SortingLayerValues.Generated.cs");
            
            UnityConstantValuesGenerator.UpdateUnityConstants(setting);
            yield return new RecompileScripts();
            
            Assert.AreEqual("12@hoge -##A", TagName._12hogeA);
            
            Assert.AreEqual(17, (int)LayerId.アイウエオ);
            Assert.AreEqual((1 << 17), (int)LayerMaskValue.アイウエオ);

            Assert.AreEqual(21, (int)LayerId._123abcWXZ11);
            Assert.AreEqual((1 << 21), (int)LayerMaskValue._123abcWXZ11);
            
            Assert.AreEqual(SortingLayer.NameToID("Default"), SortingLayerId.Default);
        }
        
    }
}
