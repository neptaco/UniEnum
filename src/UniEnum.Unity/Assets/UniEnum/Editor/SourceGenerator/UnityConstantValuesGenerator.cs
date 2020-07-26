using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UniEnumUtils.SourceGenerator
{
    public class UnityConstantValuesGenerator : AssetPostprocessor
    {
        private static GenerateSetting _settings;

        private static GenerateSetting Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = UniEnumSettings.GetOrCreate().generateSetting;
                }

                return _settings;
            }
        }
        
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            EditorBuildSettings.sceneListChanged -= OnSceneListChanged;
            EditorBuildSettings.sceneListChanged += OnSceneListChanged;
        }

        private static void OnSceneListChanged()
        {
            EditorApplication.delayCall += () => UpdateSceneValues();
        }
        
        /// <summary>
        /// Update scene values.
        /// </summary>
        /// <param name="scenes"></param>
        public static void UpdateSceneValues(EditorBuildSettingsScene[] scenes = null)
        {
            UpdateSceneValues(Settings, scenes);
        }
        
        
        internal static void UpdateSceneValues(GenerateSetting setting, EditorBuildSettingsScene[] scenes)
        {
            if (!Settings.generateSceneValues)
                return;
            
            using (AssetEditing.Scope())
            {
                if (scenes == null)
                {
                    scenes = EditorBuildSettings.scenes;
                }
                
                var sceneIds = new CSharpClass(setting.Namespace, "SceneId");
                var sceneNames = new CSharpClass(setting.Namespace, "SceneName");
                var scenePaths = new CSharpClass(setting.Namespace, "ScenePath");

                for (int i = 0; i < scenes.Length; i++)
                {
                    var scene = scenes[i];
                    var sceneName = Path.GetFileNameWithoutExtension(scene.path);
                    var comment = $"<para>{i}: {sceneName}</para>\n{scene.path}";
                    sceneIds.Fields.Add(new Variable("int", sceneName, i.ToString(), Modifier.Const, comment));
                    sceneNames.Fields.Add(new Variable("string", sceneName, sceneName.ToQuoted(), Modifier.Const, comment));
                    scenePaths.Fields.Add(new Variable("string", sceneName, scene.path.ToQuoted(), Modifier.Const, comment));
                }
                
                GenerateSourceCode(setting, "SceneValues.Generated", sceneIds, sceneNames, scenePaths);
            }    
        }

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            if (Settings.generateLayerValues ||
                Settings.generateSortingLayerValues ||
                Settings.generateTagValues)
            {
                foreach (var asset in importedAssets)
                {
                    if (asset.EndsWith("TagManager.asset", StringComparison.Ordinal))
                    {
                        UpdateUnityConstants();
                    }
                }
            }
        }

        public static void UpdateUnityConstants()
        {
            UpdateUnityConstants(Settings);
        }
        
        internal static void UpdateUnityConstants(GenerateSetting genSetting)
        {
            using (AssetEditing.Scope())
            {
                if (Settings.generateSortingLayerValues)
                {
                    CreateSortingLayerValues(genSetting);
                }

                if (Settings.generateLayerValues)
                {
                    CreateLayerValues(genSetting);
                }

                if (Settings.generateTagValues)
                {
                    CreateTagValues(genSetting);
                }
            }
        }

        private static void CreateSortingLayerValues(GenerateSetting setting)
        {
            var idClass = new CSharpClass(setting.Namespace, "SortingLayerId");
            var nameClass = new CSharpClass(setting.Namespace, "SortingLayerName");
            idClass.UsingNamespaces.Add("UnityEngine");
            foreach (var layer in SortingLayer.layers)
            {
                var idValue = $"SortingLayer.NameToID(\"{layer.name}\")";
                idClass.Fields.Add(new Variable("int", layer.name, idValue, Modifier.StaticReadonly));
                nameClass.Fields.Add(new Variable("string", layer.name, layer.name.ToQuoted(), Modifier.Const));
            }
            
            GenerateSourceCode(setting, "SortingLayerValues.Generated", idClass, nameClass);
        }

        private static void CreateLayerValues(GenerateSetting setting)
        {
            var layers = InternalEditorUtility.layers;

            var layerIdClass = new CSharpEnum(setting.Namespace, "LayerId");
            var layerMaskClass = new CSharpEnum(setting.Namespace, "LayerMaskValue")
            {
                IsFlags = true
            };

            foreach (var layer in layers)
            {
                var layerId = LayerMask.NameToLayer(layer);
                layerIdClass.Fields.Add(new Variable("int", layer, layerId.ToString(), Modifier.StaticReadonly)
                {
                    Comment = layer,
                });

                var mask = $"1 << {layerId}";
                layerMaskClass.Fields.Add(new Variable("int", layer, mask, Modifier.StaticReadonly)
                {
                    Comment = layer,
                });
            }
            GenerateSourceCode(setting, "LayerValues.Generated", layerIdClass, layerMaskClass);
        }

        private static void CreateTagValues(GenerateSetting setting)
        {
            var tags = InternalEditorUtility.tags;

            var tagNameClass = new CSharpClass(setting.Namespace, "TagName");
            foreach (var tag in tags)
            {
                tagNameClass.Fields.Add(new Variable("string", tag, tag.ToQuoted(), Modifier.StaticReadonly)
                {
                    Comment = tag,
                });
            }

            GenerateSourceCode(setting, "TagValues.Generated", tagNameClass);
        }

        private static void GenerateSourceCode(GenerateSetting setting, string fileName, params CSharpType[] types)
        {
            var path = Path.Combine(setting.OutputDir, fileName) + ".cs";
            var parent = Path.GetDirectoryName(path);
            if (!Directory.Exists(parent))
                Directory.CreateDirectory(parent);

            using (var writer = new StreamWriter(path))
            {
                var generator = new CSharpSourceGenerator(writer);
                foreach (var type in types)
                {
                    generator.AddCSharpType(type);
                }
                generator.Generate();
            }
        }
    }

}
