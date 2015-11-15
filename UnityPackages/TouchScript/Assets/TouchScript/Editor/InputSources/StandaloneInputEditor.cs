﻿using TouchScript.InputSources;
using UnityEditor;

namespace TouchScript.Editor.InputSources
{
    [CustomEditor(typeof(StandaloneInput), true)]
    internal sealed class Win8TouchInputEditor : InputSourceEditor
    {
        private SerializedProperty touchTags, mouseTags, penTags, touchAPI;

        protected override void OnEnable()
        {
            base.OnEnable();

            touchTags = serializedObject.FindProperty("TouchTags");
            mouseTags = serializedObject.FindProperty("MouseTags");
            penTags = serializedObject.FindProperty("PenTags");
            touchAPI = serializedObject.FindProperty("TouchAPI");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfDirtyOrScript();

            EditorGUILayout.PropertyField(touchAPI);

            serializedObject.ApplyModifiedProperties();
            base.OnInspectorGUI();
        }

        protected override void drawAdvanced()
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(touchTags);
            EditorGUILayout.PropertyField(mouseTags);
            EditorGUILayout.PropertyField(penTags);
            EditorGUI.indentLevel--;
        }
    }
}
