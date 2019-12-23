#if UNITY_EDITOR

namespace QuickEditor.Attributes.Editor
{
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(QuickEditor.Attributes.FolderAttribute))]
    public class FolderAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var rAttribute = this.attribute as QuickEditor.Attributes.FolderAttribute;

            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            const float ButtonSize = 18;

            position.xMax -= ButtonSize;

            var indent = EditorGUI.indentLevel;

            EditorGUI.indentLevel = 0;

            if (rAttribute.Editable)
                property.stringValue = EditorGUI.TextField(position, property.stringValue);
            else
                EditorGUI.LabelField(position, property.stringValue);

            var ButtonRect = position;
            ButtonRect.xMin = position.xMax;
            ButtonRect.xMax += ButtonSize;
            if (GUI.Button(ButtonRect, ".."))
            {
                string rNewPath = string.Empty;
                string rDefaultFolder = string.Empty;
                if (rAttribute.Type == PathType.AssetPath || rAttribute.Type == PathType.ResourcesPath)
                    rDefaultFolder = PathRoot.AssetPathRoot;
                else if (rAttribute.Type == PathType.ProjectPath)
                    rDefaultFolder = PathRoot.ProjectPathRoot;
                bool bCompleted = false;
                bool bCancel = false;
                do
                {
                    rNewPath = EditorUtility.OpenFolderPanel("select folder", rDefaultFolder, string.Empty);
                    if (string.IsNullOrEmpty(rNewPath))
                    {
                        bCancel = true;
                        break;
                    }

                    if (rAttribute.Type == PathType.AssetPath || rAttribute.Type == PathType.ProjectPath)
                    {
                        if (string.IsNullOrEmpty(rAttribute.Key) || rNewPath.Contains(rAttribute.Key))
                        {
                            bCompleted = rNewPath.Contains(rDefaultFolder);
                            rNewPath = rNewPath.Replace(rDefaultFolder, "");
                        }
                    }
                    else if (string.IsNullOrEmpty(rAttribute.Key) || rNewPath.Contains(rAttribute.Key) ||
                             string.IsNullOrEmpty(rNewPath))
                    {
                        bCompleted = true;
                    }
                }
                while (!bCompleted);

                if (!bCancel)
                    property.stringValue = rNewPath;
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(QuickEditor.Attributes.FilePathAttribute))]
    public class FilePathAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var rAttribute = this.attribute as QuickEditor.Attributes.FilePathAttribute;

            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            const float ButtonSize = 18;

            position.xMax -= ButtonSize;

            var indent = EditorGUI.indentLevel;

            EditorGUI.indentLevel = 0;

            if (rAttribute.Editable)
                property.stringValue = EditorGUI.TextField(position, property.stringValue);
            else
                EditorGUI.LabelField(position, property.stringValue);

            var ButtonRect = position;
            ButtonRect.xMin = position.xMax;
            ButtonRect.xMax += ButtonSize;
            if (GUI.Button(ButtonRect, ".."))
            {
                string rNewPath = string.Empty;
                string rDefaultFolder = string.Empty;
                if (rAttribute.Type == PathType.AssetPath || rAttribute.Type == PathType.ResourcesPath)
                    rDefaultFolder = PathRoot.AssetPathRoot;
                else if (rAttribute.Type == PathType.ProjectPath)
                    rDefaultFolder = PathRoot.ProjectPathRoot;
                bool bCompleted = false;
                bool bCancel = false;
                do
                {
                    rNewPath = EditorUtility.OpenFilePanelWithFilters("Select File", rDefaultFolder, rAttribute.Filters);
                    if (string.IsNullOrEmpty(rNewPath))
                    {
                        bCancel = true;
                        break;
                    }

                    if (rAttribute.Type == PathType.AssetPath || rAttribute.Type == PathType.ProjectPath)
                    {
                        bCompleted = rNewPath.Contains(rDefaultFolder);
                        rNewPath = rNewPath.Replace(rDefaultFolder, "");
                    }
                    else
                    {
                        bCompleted = true;
                    }
                }
                while (!bCompleted);

                if (!bCancel)
                    property.stringValue = rNewPath;
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}

#endif