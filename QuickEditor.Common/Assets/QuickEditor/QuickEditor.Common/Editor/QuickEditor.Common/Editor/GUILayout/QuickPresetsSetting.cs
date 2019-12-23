#if UNITY_EDITOR

namespace QuickEditor.Common
{
    using UnityEditor;
    using UnityEngine;

    public abstract class QuickPresetsSetting
    {
        protected bool Folded = false;

        [HideInInspector]
        public bool TagForDeletion = false;

        [HideInInspector]
        public int PositionOffset = 0;

        [SerializeField]
        public string SaveName = "New Preset";

        [SerializeField]
        public string PathNameFilter = string.Empty;

        [SerializeField]
        public string FileNameFilter = string.Empty;

        [SerializeField]
        public bool IsEnabled = true;

        public abstract void DrawInnerGUI();

        protected virtual void DrawFilterGUI()
        {
            EditorGUILayout.LabelField("Preset Settings", EditorStyles.boldLabel);
            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 2), QuickEditorColors.DarkGrayX11);
            GUILayout.Space(3);

            SaveName = EditorGUILayout.TextField(new GUIContent("Name", "Only used for organisation"), SaveName);
            PathNameFilter = EditorGUILayout.TextField(new GUIContent("Path Contains Filter", "Applied only if the path contains this string. Leave empty to apply to all paths. Separate multiple filters with ;"), PathNameFilter);
            FileNameFilter = EditorGUILayout.TextField(new GUIContent("Filename Contains Filter", "Applied only if the filename contains this string. Leave empty to apply to all filenames. Separate multiple filters with ;"), FileNameFilter);

            if (PathNameFilter.Length == 0 && FileNameFilter.Length == 0)
            {
                EditorGUILayout.HelpBox("Empty filters means this will be applied to all imported meshes", MessageType.Info);
            }
        }
    }
}

#endif