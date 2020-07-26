using System;
using System.Collections;
using System.Collections.Generic;
using UniEnumUtils.SourceGenerator;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace UniEnumUtils
{
    public class UniEnumSettingsProvider : SettingsProvider
    {
        private static class Styles
        {
            public static readonly GUIContent SourceGenerationLabel = new GUIContent("Source Generation", "Source code generation settings");
            public static readonly GUIContent GenerateTargetsLabel = new GUIContent("Targets");
        }
        
        private SerializedObject _serializedObject;
        
        private SerializedProperty _generateSettingsProp;
        
        private SerializedProperty _namespaceProp;
        private SerializedProperty _outputPathProp;
        
        private SerializedProperty _generateSceneProp;
        private SerializedProperty _generateSortingLayerProp;
        private SerializedProperty _generateLayerProp;
        private SerializedProperty _generateTagProp;
        

        [SettingsProvider]
        public static SettingsProvider Create()
        {
            var path = "Project/UniEnum";
            var settings = UniEnumSettings.GetSerializedObject();
            var provider = new UniEnumSettingsProvider(path, SettingsScope.Project)
            {
                keywords = GetSearchKeywordsFromSerializedObject(settings)
            };

            return provider;
        }

        private UniEnumSettingsProvider(string path, SettingsScope scopes) : base(path, scopes)
        { }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            base.OnActivate(searchContext, rootElement);
            
            _serializedObject = UniEnumSettings.GetSerializedObject();

            _generateSettingsProp = _serializedObject.FindProperty(nameof(UniEnumSettings.generateSetting));

            _namespaceProp = _generateSettingsProp.FindPropertyRelative(nameof(GenerateSetting.Namespace));
            _outputPathProp = _generateSettingsProp.FindPropertyRelative(nameof(GenerateSetting.OutputDir));
            
            _generateSceneProp = _generateSettingsProp.FindPropertyRelative(nameof(GenerateSetting.generateSceneValues));
            _generateSortingLayerProp = _generateSettingsProp.FindPropertyRelative(nameof(GenerateSetting.generateSortingLayerValues));
            _generateLayerProp = _generateSettingsProp.FindPropertyRelative(nameof(GenerateSetting.generateLayerValues));
            _generateTagProp = _generateSettingsProp.FindPropertyRelative(nameof(GenerateSetting.generateTagValues));

        }

        private struct LabeledScope : IDisposable
        {
            public LabeledScope(GUIContent labelContent) 
                : this(labelContent, GUIStyle.none)
            {
                
            }

            public LabeledScope(GUIContent labelContent, GUIStyle boxStyle)
            {
                EditorGUILayout.BeginVertical(boxStyle);
                EditorGUILayout.LabelField(labelContent, EditorStyles.boldLabel);
                EditorGUI.indentLevel++;
            }

            public void Dispose()
            {
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }
        }

        public override void OnGUI(string searchContext)
        {
            _serializedObject.UpdateIfRequiredOrScript();

            using (new LabeledScope(Styles.SourceGenerationLabel))
            {
                EditorGUILayout.PropertyField(_namespaceProp, new GUIContent("Namespace"));
                EditorGUILayout.PropertyField(_outputPathProp, new GUIContent("Output Directory"));

                using (new LabeledScope(Styles.GenerateTargetsLabel))
                {
                    EditorGUILayout.PropertyField(_generateSceneProp, new GUIContent("Scene"));
                    EditorGUILayout.PropertyField(_generateSortingLayerProp, new GUIContent("SortingLayer"));
                    EditorGUILayout.PropertyField(_generateLayerProp, new GUIContent("Layer"));
                    EditorGUILayout.PropertyField(_generateTagProp, new GUIContent("Tag"));
                }
                EditorGUILayout.Space();
                
                if (GUILayout.Button("Generate", EditorStyles.miniButtonRight))
                {
                    using (AssetEditing.Scope())
                    {
                        UnityConstantValuesGenerator.UpdateUnityConstants();
                        UnityConstantValuesGenerator.UpdateSceneValues();
                    }
                    AssetDatabase.Refresh();
                }

            }

            _serializedObject.ApplyModifiedProperties();
        }

    }
}
