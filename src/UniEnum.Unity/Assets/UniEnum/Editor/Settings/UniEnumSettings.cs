using System.IO;
using UniEnumUtils.SourceGenerator;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace UniEnumUtils
{
    public class UniEnumSettings : ScriptableObject
    {
        private const string SavePath = "Assets/Plugins/UniEnum/UniEnumSettings.asset";

        private const string ConfigName = nameof(UniEnumSettings);

        public GenerateSetting generateSetting;

        public static UniEnumSettings GetOrCreate()
        {
            if (!EditorBuildSettings.TryGetConfigObject<UniEnumSettings>(ConfigName, out var settings))
            {
                settings = AssetDatabase.LoadAssetAtPath<UniEnumSettings>(SavePath);
                if (settings == null)
                {
                    var dir = Path.GetDirectoryName(SavePath);
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    settings = CreateInstance<UniEnumSettings>();
                    AssetDatabase.CreateAsset(settings, SavePath);
                    AssetDatabase.Refresh();
                }

                EditorBuildSettings.AddConfigObject(ConfigName, settings, true);
            }

            return settings;
        }

        internal static SerializedObject GetSerializedObject()
        {
            var serializedObject = new SerializedObject(GetOrCreate());
            serializedObject.UpdateIfRequiredOrScript();
            return serializedObject;
        } 
    }
}
