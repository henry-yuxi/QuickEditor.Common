#if UNITY_EDITOR

namespace QuickEditor.Attributes.Editor
{
    using System;
    using System.Reflection;
    using UnityEditor;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(EnumMaskAttribute))]
    public class EnumMaskAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var rTargetEnum = GetBaseProperty<Enum>(property);

            EditorGUI.BeginProperty(position, label, property);

            if (rTargetEnum.GetType().IsDefined(typeof(FlagsAttribute), false))
            {
                var rNewEnumValue = EditorGUI.EnumFlagsField(position, label, rTargetEnum);
                property.intValue = (int)Convert.ChangeType(rNewEnumValue, rTargetEnum.GetType());
            }
            else
            {
                var rNewEnumValue = EditorGUI.EnumPopup(position, label, rTargetEnum);
                property.intValue = (int)Convert.ChangeType(rNewEnumValue, rTargetEnum.GetType());
            }

            EditorGUI.EndProperty();
        }

        private static T GetBaseProperty<T>(SerializedProperty prop)
        {
            string[] separatedPaths = prop.propertyPath.Split('.');

            System.Object reflectionTarget = prop.serializedObject.targetObject as object;

            foreach (var path in separatedPaths)
            {
                FieldInfo fieldInfo = reflectionTarget.GetType().GetField(path);
                reflectionTarget = fieldInfo.GetValue(reflectionTarget);
            }
            return (T)reflectionTarget;
        }
    }
}

#endif