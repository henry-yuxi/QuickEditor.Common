namespace QuickEditor.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.Internal;

    public static class QuickGUILayoutWrapper
    {
        #region UNITY API 重写

        #region GUILayout

        public static void Button(string text, GUIStyle style, Action action, params GUILayoutOption[] options)
        {
            if (GUILayout.Button(text, style, options))
            {
                if (action != null) { action(); }
            }
        }

        public static void Button(Texture image, GUIStyle style, Action action, params GUILayoutOption[] options)
        {
            if (GUILayout.Button(image, style, options))
            {
                if (action != null) { action(); }
            }
        }

        public static void Button(GUIContent content, Action action, params GUILayoutOption[] options)
        {
            if (GUILayout.Button(content, options))
            {
                if (action != null) { action(); }
            }
        }

        public static void Button(string text, Action action, params GUILayoutOption[] options)
        {
            if (GUILayout.Button(text, options))
            {
                if (action != null) { action(); }
            }
        }

        public static void Button(Texture image, Action action, params GUILayoutOption[] options)
        {
            if (GUILayout.Button(image, options))
            {
                if (action != null) { action(); }
            }
        }

        public static void Button(GUIContent content, GUIStyle style, Action action, params GUILayoutOption[] options)
        {
            if (GUILayout.Button(content, style, options))
            {
                if (action != null) { action(); }
            }
        }

        public static bool Button(Texture image, params GUILayoutOption[] options)
        {
            return GUILayout.Button(image, options);
        }

        public static bool Button(string text, params GUILayoutOption[] options)
        {
            return GUILayout.Button(text, options);
        }

        public static bool Button(GUIContent content, params GUILayoutOption[] options)
        {
            return GUILayout.Button(content, options);
        }

        public static bool Button(Texture image, GUIStyle style, params GUILayoutOption[] options)
        {
            return GUILayout.Button(image, style, options);
        }

        public static bool Button(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            return GUILayout.Button(text, style, options);
        }

        public static bool Button(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
        {
            return GUILayout.Button(content, style, options);
        }

        public static bool RepeatButton(Texture image, params GUILayoutOption[] options)
        {
            return GUILayout.RepeatButton(image, options);
        }

        public static bool RepeatButton(string text, params GUILayoutOption[] options)
        {
            return GUILayout.RepeatButton(text, options);
        }

        public static bool RepeatButton(GUIContent content, params GUILayoutOption[] options)
        {
            return GUILayout.RepeatButton(content, options);
        }

        public static bool RepeatButton(Texture image, GUIStyle style, params GUILayoutOption[] options)
        {
            return GUILayout.RepeatButton(image, style, options);
        }

        public static bool RepeatButton(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            return GUILayout.RepeatButton(text, style, options);
        }

        public static bool RepeatButton(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
        {
            return GUILayout.RepeatButton(content, style, options);
        }

        public static void Box(Texture image, params GUILayoutOption[] options)
        {
            GUILayout.Box(image, options);
        }

        public static void Box(string text, params GUILayoutOption[] options)
        {
            GUILayout.Box(text, options);
        }

        public static void Box(GUIContent content, params GUILayoutOption[] options)
        {
            GUILayout.Box(content, options);
        }

        public static void Box(Texture image, GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.Box(image, style, options);
        }

        public static void Box(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.Box(text, style, options);
        }

        public static void Box(GUIContent content, GUIStyle style, params GUILayoutOption[] options)
        {
            GUILayout.Box(content, style, options);
        }

        public static void Space(float pixels)
        {
            GUILayout.Space(pixels);
        }

        public static void FlexibleSpace()
        {
            GUILayout.FlexibleSpace();
        }

        #endregion GUILayout

        #region EditorGUILayout

        public static bool Foldout(bool foldout, string content)
        {
            return EditorGUILayout.Foldout(foldout, content);
        }

        public static bool Foldout(bool foldout, string content, GUIStyle style)
        {
            return EditorGUILayout.Foldout(foldout, content, style);
        }

        public static bool Foldout(bool foldout, GUIContent content)
        {
            return EditorGUILayout.Foldout(foldout, content);
        }

        public static bool Foldout(bool foldout, GUIContent content, GUIStyle style)
        {
            return EditorGUILayout.Foldout(foldout, content, style);
        }

        public static bool Foldout(bool foldout, string content, bool toggleOnLabelClick)
        {
            return EditorGUILayout.Foldout(foldout, content, toggleOnLabelClick);
        }

        public static bool Foldout(bool foldout, string content, bool toggleOnLabelClick, GUIStyle style)
        {
            return EditorGUILayout.Foldout(foldout, content, toggleOnLabelClick, style);
        }

        public static bool Foldout(bool foldout, GUIContent content, bool toggleOnLabelClick)
        {
            return EditorGUILayout.Foldout(foldout, content, toggleOnLabelClick);
        }

        public static bool Foldout(bool foldout, GUIContent content, bool toggleOnLabelClick, GUIStyle style)
        {
            return EditorGUILayout.Foldout(foldout, content, toggleOnLabelClick, style);
        }

        public static void PrefixLabel(string label)
        {
            EditorGUILayout.PrefixLabel(label);
        }

        public static void PrefixLabel(string label, GUIStyle followingStyle)
        {
            EditorGUILayout.PrefixLabel(label, followingStyle);
        }

        public static void PrefixLabel(string label, GUIStyle followingStyle, GUIStyle labelStyle)
        {
            EditorGUILayout.PrefixLabel(label, followingStyle, labelStyle);
        }

        public static void PrefixLabel(GUIContent label)
        {
            EditorGUILayout.PrefixLabel(label);
        }

        public static void PrefixLabel(GUIContent label, GUIStyle followingStyle)
        {
            EditorGUILayout.PrefixLabel(label, followingStyle);
        }

        public static void PrefixLabel(GUIContent label, GUIStyle followingStyle, GUIStyle labelStyle)
        {
            EditorGUILayout.PrefixLabel(label, followingStyle, labelStyle);
        }

        public static void LabelField(string label, params GUILayoutOption[] options)
        {
            EditorGUILayout.LabelField(label, options);
        }

        public static void LabelField(string label, GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUILayout.LabelField(label, style, options);
        }

        public static void LabelField(GUIContent label, params GUILayoutOption[] options)
        {
            EditorGUILayout.LabelField(label, options);
        }

        public static void LabelField(GUIContent label, GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUILayout.LabelField(label, style, options);
        }

        public static void LabelField(string label, string label2, params GUILayoutOption[] options)
        {
            EditorGUILayout.LabelField(label, label2, options);
        }

        public static void LabelField(string label, string label2, GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUILayout.LabelField(label, label2, style, options);
        }

        public static void LabelField(GUIContent label, GUIContent label2, params GUILayoutOption[] options)
        {
            EditorGUILayout.LabelField(label, label2, options);
        }

        public static void LabelField(GUIContent label, GUIContent label2, GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUILayout.LabelField(label, label2, style, options);
        }

        public static bool Toggle(bool value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Toggle(value, options);
        }

        public static bool Toggle(string label, bool value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Toggle(label, value, options);
        }

        public static bool Toggle(GUIContent label, bool value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Toggle(label, value, options);
        }

        public static bool Toggle(bool value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Toggle(value, style, options);
        }

        public static bool Toggle(string label, bool value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Toggle(label, value, style, options);
        }

        public static bool Toggle(GUIContent label, bool value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Toggle(label, value, style, options);
        }

        public static bool ToggleLeft(string label, bool value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.ToggleLeft(label, value, options);
        }

        public static bool ToggleLeft(GUIContent label, bool value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.ToggleLeft(label, value, options);
        }

        public static bool ToggleLeft(string label, bool value, GUIStyle labelStyle, params GUILayoutOption[] options)
        {
            return EditorGUILayout.ToggleLeft(label, value, labelStyle, options);
        }

        public static bool ToggleLeft(GUIContent label, bool value, GUIStyle labelStyle, params GUILayoutOption[] options)
        {
            return EditorGUILayout.ToggleLeft(label, value, labelStyle, options);
        }

        public static string TextField(string text, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TextField(text, options);
        }

        public static string TextField(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TextField(text, style, options);
        }

        public static string TextField(string label, string text, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TextField(label, text, options);
        }

        public static string TextField(string label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TextField(label, text, style, options);
        }

        public static string TextField(GUIContent label, string text, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TextField(label, text, options);
        }

        public static string TextField(GUIContent label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TextField(label, text, style, options);
        }

        public static string DelayedTextField(string text, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedTextField(text, options);
        }

        public static string DelayedTextField(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedTextField(text, style, options);
        }

        public static string DelayedTextField(string label, string text, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedTextField(label, text, options);
        }

        public static string DelayedTextField(string label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedTextField(label, text, style, options);
        }

        public static string DelayedTextField(GUIContent label, string text, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedTextField(label, text, options);
        }

        public static string DelayedTextField(GUIContent label, string text, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedTextField(label, text, style, options);
        }

        public static void DelayedTextField(SerializedProperty property, params GUILayoutOption[] options)
        {
            EditorGUILayout.DelayedTextField(property, options);
        }

        public static void DelayedTextField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            EditorGUILayout.DelayedTextField(property, label, options);
        }

        public static string TextArea(string text, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TextArea(text, options);
        }

        public static string TextArea(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TextArea(text, style, options);
        }

        public static void SelectableLabel(string text, params GUILayoutOption[] options)
        {
            EditorGUILayout.SelectableLabel(text, options);
        }

        public static void SelectableLabel(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUILayout.SelectableLabel(text, style, options);
        }

        public static string PasswordField(string password, params GUILayoutOption[] options)
        {
            return EditorGUILayout.PasswordField(password, options);
        }

        public static string PasswordField(string password, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.PasswordField(password, style, options);
        }

        public static string PasswordField(string label, string password, params GUILayoutOption[] options)
        {
            return EditorGUILayout.PasswordField(label, password, options);
        }

        public static string PasswordField(string label, string password, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.PasswordField(label, password, style, options);
        }

        public static string PasswordField(GUIContent label, string password, params GUILayoutOption[] options)
        {
            return EditorGUILayout.PasswordField(label, password, options);
        }

        public static string PasswordField(GUIContent label, string password, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.PasswordField(label, password, style, options);
        }

        public static float FloatField(float value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.FloatField(value, options);
        }

        public static float FloatField(float value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.FloatField(value, style, options);
        }

        public static float FloatField(string label, float value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.FloatField(label, value, options);
        }

        public static float FloatField(string label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.FloatField(label, value, style, options);
        }

        public static float FloatField(GUIContent label, float value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.FloatField(label, value, options);
        }

        public static float FloatField(GUIContent label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.FloatField(label, value, style, options);
        }

        public static float DelayedFloatField(float value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedFloatField(value, options);
        }

        public static float DelayedFloatField(float value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedFloatField(value, style, options);
        }

        public static float DelayedFloatField(string label, float value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedFloatField(label, value, options);
        }

        public static float DelayedFloatField(string label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedFloatField(label, value, style, options);
        }

        public static float DelayedFloatField(GUIContent label, float value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedFloatField(label, value, options);
        }

        public static float DelayedFloatField(GUIContent label, float value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedFloatField(label, value, style, options);
        }

        public static void DelayedFloatField(SerializedProperty property, params GUILayoutOption[] options)
        {
            EditorGUILayout.DelayedFloatField(property, options);
        }

        public static void DelayedFloatField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            EditorGUILayout.DelayedFloatField(property, label, options);
        }

        public static double DoubleField(double value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DoubleField(value, options);
        }

        public static double DoubleField(double value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DoubleField(value, style, options);
        }

        public static double DoubleField(string label, double value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DoubleField(label, value, options);
        }

        public static double DoubleField(string label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DoubleField(label, value, style, options);
        }

        public static double DoubleField(GUIContent label, double value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DoubleField(label, value, options);
        }

        public static double DoubleField(GUIContent label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DoubleField(label, value, style, options);
        }

        public static double DelayedDoubleField(double value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedDoubleField(value, options);
        }

        public static double DelayedDoubleField(double value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedDoubleField(value, style, options);
        }

        public static double DelayedDoubleField(string label, double value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedDoubleField(label, value, options);
        }

        public static double DelayedDoubleField(string label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedDoubleField(label, value, style, options);
        }

        public static double DelayedDoubleField(GUIContent label, double value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedDoubleField(label, value, options);
        }

        public static double DelayedDoubleField(GUIContent label, double value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedDoubleField(label, value, style, options);
        }

        public static int IntField(int value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntField(value, options);
        }

        public static int IntField(int value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntField(value, style, options);
        }

        public static int IntField(string label, int value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntField(label, value, options);
        }

        public static int IntField(string label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntField(label, value, style, options);
        }

        public static int IntField(GUIContent label, int value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntField(label, value, options);
        }

        public static int IntField(GUIContent label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntField(label, value, style, options);
        }

        public static int DelayedIntField(int value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedIntField(value, options);
        }

        public static int DelayedIntField(int value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedIntField(value, style, options);
        }

        public static int DelayedIntField(string label, int value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedIntField(label, value, options);
        }

        public static int DelayedIntField(string label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedIntField(label, value, style, options);
        }

        public static int DelayedIntField(GUIContent label, int value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedIntField(label, value, options);
        }

        public static int DelayedIntField(GUIContent label, int value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DelayedIntField(label, value, style, options);
        }

        public static void DelayedIntField(SerializedProperty property, params GUILayoutOption[] options)
        {
            EditorGUILayout.DelayedIntField(property, options);
        }

        public static void DelayedIntField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            EditorGUILayout.DelayedIntField(property, label, options);
        }

        public static long LongField(long value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LongField(value, options);
        }

        public static long LongField(long value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LongField(value, style, options);
        }

        public static long LongField(string label, long value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LongField(label, value, options);
        }

        public static long LongField(string label, long value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LongField(label, value, style, options);
        }

        public static long LongField(GUIContent label, long value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LongField(label, value, options);
        }

        public static long LongField(GUIContent label, long value, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LongField(label, value, style, options);
        }

        public static float Slider(float value, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Slider(value, leftValue, rightValue, options);
        }

        public static float Slider(string label, float value, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Slider
            (
                label, value, leftValue, rightValue,
                options
            );
        }

        public static float Slider(GUIContent label, float value, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Slider
            (
                label, value, leftValue, rightValue,
                options
            );
        }

        public static void Slider(SerializedProperty property, float leftValue, float rightValue, params GUILayoutOption[] options)
        {
            EditorGUILayout.Slider(property, leftValue, rightValue, options);
        }

        public static void Slider(SerializedProperty property, float leftValue, float rightValue, string label, params GUILayoutOption[] options)
        {
            EditorGUILayout.Slider
            (
                property, leftValue, rightValue, label,
                options
            );
        }

        public static void Slider(SerializedProperty property, float leftValue, float rightValue, GUIContent label, params GUILayoutOption[] options)
        {
            EditorGUILayout.Slider
            (
                property, leftValue, rightValue, label,
                options
            );
        }

        public static int IntSlider(int value, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntSlider(value, leftValue, rightValue, options);
        }

        public static int IntSlider(string label, int value, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntSlider
            (
                label, value, leftValue, rightValue,
                options
            );
        }

        public static int IntSlider(GUIContent label, int value, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntSlider
            (
                label, value, leftValue, rightValue,
                options
            );
        }

        public static void IntSlider(SerializedProperty property, int leftValue, int rightValue, params GUILayoutOption[] options)
        {
            EditorGUILayout.IntSlider(property, leftValue, rightValue, options);
        }

        public static void IntSlider(SerializedProperty property, int leftValue, int rightValue, string label, params GUILayoutOption[] options)
        {
            EditorGUILayout.IntSlider
            (
                property, leftValue, rightValue, label,
                options
            );
        }

        public static void IntSlider(SerializedProperty property, int leftValue, int rightValue, GUIContent label, params GUILayoutOption[] options)
        {
            EditorGUILayout.IntSlider
            (
                property, leftValue, rightValue, label,
                options
            );
        }

        public static int Popup(int selectedIndex, String[] displayedOptions, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Popup(selectedIndex, displayedOptions, options);
        }

        public static int Popup(int selectedIndex, String[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Popup(selectedIndex, displayedOptions, style, options);
        }

        public static int Popup(int selectedIndex, GUIContent[] displayedOptions, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Popup(selectedIndex, displayedOptions, options);
        }

        public static int Popup(int selectedIndex, GUIContent[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Popup(selectedIndex, displayedOptions, style, options);
        }

        public static int Popup(string label, int selectedIndex, String[] displayedOptions, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Popup(label, selectedIndex, displayedOptions, options);
        }

        public static int Popup(GUIContent label, int selectedIndex, String[] displayedOptions, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Popup(label, selectedIndex, displayedOptions, options);
        }

        public static int Popup(string label, int selectedIndex, String[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Popup
            (
                label, selectedIndex, displayedOptions, style,
                options
            );
        }

        public static int Popup(GUIContent label, int selectedIndex, GUIContent[] displayedOptions, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Popup(label, selectedIndex, displayedOptions, options);
        }

        public static int Popup(GUIContent label, int selectedIndex, GUIContent[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Popup
            (
                label, selectedIndex, displayedOptions, style,
                options
            );
        }

        public static Enum EnumPopup(Enum selected, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumPopup(selected, options);
        }

        public static Enum EnumPopup(Enum selected, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumPopup(selected, style, options);
        }

        public static Enum EnumPopup(string label, Enum selected, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumPopup(label, selected, options);
        }

        public static Enum EnumPopup(string label, Enum selected, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumPopup(label, selected, style, options);
        }

        public static Enum EnumPopup(GUIContent label, Enum selected, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumPopup(label, selected, options);
        }

        public static Enum EnumPopup(GUIContent label, Enum selected, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumPopup(label, selected, style, options);
        }

        public static Enum EnumPopup(GUIContent label, Enum selected, Func<Enum, bool> checkEnabled, bool includeObsolete, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumPopup
            (
                label, selected, checkEnabled, includeObsolete,
                options
            );
        }

        public static Enum EnumPopup(GUIContent label, Enum selected, Func<Enum, bool> checkEnabled, bool includeObsolete, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumPopup
            (
                label, selected, checkEnabled, includeObsolete,
                style, options
            );
        }

        public static int IntPopup(int selectedValue, String[] displayedOptions, Int32[] optionValues, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntPopup(selectedValue, displayedOptions, optionValues, options);
        }

        public static int IntPopup(int selectedValue, String[] displayedOptions, Int32[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntPopup
            (
                selectedValue, displayedOptions, optionValues, style,
                options
            );
        }

        public static int IntPopup(int selectedValue, GUIContent[] displayedOptions, Int32[] optionValues, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntPopup(selectedValue, displayedOptions, optionValues, options);
        }

        public static int IntPopup(int selectedValue, GUIContent[] displayedOptions, Int32[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntPopup
            (
                selectedValue, displayedOptions, optionValues, style,
                options
            );
        }

        public static int IntPopup(string label, int selectedValue, String[] displayedOptions, Int32[] optionValues, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntPopup
            (
                label, selectedValue, displayedOptions, optionValues,
                options
            );
        }

        public static int IntPopup(string label, int selectedValue, String[] displayedOptions, Int32[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntPopup
            (
                label, selectedValue, displayedOptions, optionValues,
                style, options
            );
        }

        public static int IntPopup(GUIContent label, int selectedValue, GUIContent[] displayedOptions, Int32[] optionValues, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntPopup
            (
                label, selectedValue, displayedOptions, optionValues,
                options
            );
        }

        public static int IntPopup(GUIContent label, int selectedValue, GUIContent[] displayedOptions, Int32[] optionValues, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.IntPopup
            (
                label, selectedValue, displayedOptions, optionValues,
                style, options
            );
        }

        public static void IntPopup(SerializedProperty property, GUIContent[] displayedOptions, Int32[] optionValues, params GUILayoutOption[] options)
        {
            EditorGUILayout.IntPopup(property, displayedOptions, optionValues, options);
        }

        public static void IntPopup(SerializedProperty property, GUIContent[] displayedOptions, Int32[] optionValues, GUIContent label, params GUILayoutOption[] options)
        {
            EditorGUILayout.IntPopup
            (
                property, displayedOptions, optionValues, label,
                options
            );
        }

        public static string TagField(string tag, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TagField(tag, options);
        }

        public static string TagField(string tag, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TagField(tag, style, options);
        }

        public static string TagField(string label, string tag, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TagField(label, tag, options);
        }

        public static string TagField(string label, string tag, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TagField(label, tag, style, options);
        }

        public static string TagField(GUIContent label, string tag, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TagField(label, tag, options);
        }

        public static string TagField(GUIContent label, string tag, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.TagField(label, tag, style, options);
        }

        public static int LayerField(int layer, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LayerField(layer, options);
        }

        public static int LayerField(int layer, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LayerField(layer, style, options);
        }

        public static int LayerField(string label, int layer, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LayerField(label, layer, options);
        }

        public static int LayerField(string label, int layer, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LayerField(label, layer, style, options);
        }

        public static int LayerField(GUIContent label, int layer, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LayerField(label, layer, options);
        }

        public static int LayerField(GUIContent label, int layer, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.LayerField(label, layer, style, options);
        }

        public static int MaskField(GUIContent label, int mask, String[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.MaskField
            (
                label, mask, displayedOptions, style,
                options
            );
        }

        public static int MaskField(string label, int mask, String[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.MaskField
            (
                label, mask, displayedOptions, style,
                options
            );
        }

        public static int MaskField(GUIContent label, int mask, String[] displayedOptions, params GUILayoutOption[] options)
        {
            return EditorGUILayout.MaskField(label, mask, displayedOptions, options);
        }

        public static int MaskField(string label, int mask, String[] displayedOptions, params GUILayoutOption[] options)
        {
            return EditorGUILayout.MaskField(label, mask, displayedOptions, options);
        }

        public static int MaskField(int mask, String[] displayedOptions, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.MaskField(mask, displayedOptions, style, options);
        }

        public static int MaskField(int mask, String[] displayedOptions, params GUILayoutOption[] options)
        {
            return EditorGUILayout.MaskField(mask, displayedOptions, options);
        }

        public static Enum EnumFlagsField(Enum enumValue, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumFlagsField(enumValue, options);
        }

        public static Enum EnumFlagsField(Enum enumValue, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumFlagsField(enumValue, style, options);
        }

        public static Enum EnumFlagsField(string label, Enum enumValue, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumFlagsField(label, enumValue, options);
        }

        public static Enum EnumFlagsField(string label, Enum enumValue, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumFlagsField(label, enumValue, style, options);
        }

        public static Enum EnumFlagsField(GUIContent label, Enum enumValue, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumFlagsField(label, enumValue, options);
        }

        public static Enum EnumFlagsField(GUIContent label, Enum enumValue, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumFlagsField(label, enumValue, style, options);
        }

        public static Enum EnumFlagsField(GUIContent label, Enum enumValue, bool includeObsolete, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumFlagsField(label, enumValue, includeObsolete, options);
        }

        public static Enum EnumFlagsField(GUIContent label, Enum enumValue, bool includeObsolete, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.EnumFlagsField
            (
                label, enumValue, includeObsolete, style,
                options
            );
        }

        public static UnityEngine.Object ObjectField(UnityEngine.Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options)
        {
            return EditorGUILayout.ObjectField(obj, objType, allowSceneObjects, options);
        }

        public static UnityEngine.Object ObjectField(string label, UnityEngine.Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options)
        {
            return EditorGUILayout.ObjectField
            (
                label, obj, objType, allowSceneObjects,
                options
            );
        }

        public static UnityEngine.Object ObjectField(GUIContent label, UnityEngine.Object obj, Type objType, bool allowSceneObjects, params GUILayoutOption[] options)
        {
            return EditorGUILayout.ObjectField
            (
                label, obj, objType, allowSceneObjects,
                options
            );
        }

        public static void ObjectField(SerializedProperty property, params GUILayoutOption[] options)
        {
            EditorGUILayout.ObjectField(property, options);
        }

        public static void ObjectField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            EditorGUILayout.ObjectField(property, label, options);
        }

        public static void ObjectField(SerializedProperty property, Type objType, params GUILayoutOption[] options)
        {
            EditorGUILayout.ObjectField(property, objType, options);
        }

        public static void ObjectField(SerializedProperty property, Type objType, GUIContent label, params GUILayoutOption[] options)
        {
            EditorGUILayout.ObjectField(property, objType, label, options);
        }

        public static Vector2 Vector2Field(string label, Vector2 value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Vector2Field(label, value, options);
        }

        public static Vector2 Vector2Field(GUIContent label, Vector2 value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Vector2Field(label, value, options);
        }

        public static Vector3 Vector3Field(string label, Vector3 value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Vector3Field(label, value, options);
        }

        public static Vector3 Vector3Field(GUIContent label, Vector3 value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Vector3Field(label, value, options);
        }

        public static Vector4 Vector4Field(string label, Vector4 value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Vector4Field(label, value, options);
        }

        public static Vector4 Vector4Field(GUIContent label, Vector4 value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Vector4Field(label, value, options);
        }

        public static Vector2Int Vector2IntField(string label, Vector2Int value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Vector2IntField(label, value, options);
        }

        public static Vector2Int Vector2IntField(GUIContent label, Vector2Int value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Vector2IntField(label, value, options);
        }

        public static Vector3Int Vector3IntField(string label, Vector3Int value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Vector3IntField(label, value, options);
        }

        public static Vector3Int Vector3IntField(GUIContent label, Vector3Int value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Vector3IntField(label, value, options);
        }

        public static Rect RectField(Rect value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.RectField(value, options);
        }

        public static Rect RectField(string label, Rect value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.RectField(label, value, options);
        }

        public static Rect RectField(GUIContent label, Rect value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.RectField(label, value, options);
        }

        public static RectInt RectIntField(RectInt value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.RectIntField(value, options);
        }

        public static RectInt RectIntField(string label, RectInt value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.RectIntField(label, value, options);
        }

        public static RectInt RectIntField(GUIContent label, RectInt value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.RectIntField(label, value, options);
        }

        public static Bounds BoundsField(Bounds value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BoundsField(value, options);
        }

        public static Bounds BoundsField(string label, Bounds value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BoundsField(label, value, options);
        }

        public static Bounds BoundsField(GUIContent label, Bounds value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BoundsField(label, value, options);
        }

        public static BoundsInt BoundsIntField(BoundsInt value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BoundsIntField(value, options);
        }

        public static BoundsInt BoundsIntField(string label, BoundsInt value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BoundsIntField(label, value, options);
        }

        public static BoundsInt BoundsIntField(GUIContent label, BoundsInt value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BoundsIntField(label, value, options);
        }

        public static Color ColorField(Color value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.ColorField(value, options);
        }

        public static Color ColorField(string label, Color value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.ColorField(label, value, options);
        }

        public static Color ColorField(GUIContent label, Color value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.ColorField(label, value, options);
        }

        public static Color ColorField(GUIContent label, Color value, bool showEyedropper, bool showAlpha, bool hdr, params GUILayoutOption[] options)
        {
            return EditorGUILayout.ColorField
            (
                label, value, showEyedropper, showAlpha,
                hdr, options
            );
        }

        public static AnimationCurve CurveField(AnimationCurve value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.CurveField(value, options);
        }

        public static AnimationCurve CurveField(string label, AnimationCurve value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.CurveField(label, value, options);
        }

        public static AnimationCurve CurveField(GUIContent label, AnimationCurve value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.CurveField(label, value, options);
        }

        public static AnimationCurve CurveField(AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            return EditorGUILayout.CurveField(value, color, ranges, options);
        }

        public static AnimationCurve CurveField(string label, AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            return EditorGUILayout.CurveField
            (
                label, value, color, ranges,
                options
            );
        }

        public static AnimationCurve CurveField(GUIContent label, AnimationCurve value, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            return EditorGUILayout.CurveField
            (
                label, value, color, ranges,
                options
            );
        }

        public static void CurveField(SerializedProperty property, Color color, Rect ranges, params GUILayoutOption[] options)
        {
            EditorGUILayout.CurveField(property, color, ranges, options);
        }

        public static void CurveField(SerializedProperty property, Color color, Rect ranges, GUIContent label, params GUILayoutOption[] options)
        {
            EditorGUILayout.CurveField
            (
                property, color, ranges, label,
                options
            );
        }

        public static bool InspectorTitlebar(bool foldout, UnityEngine.Object targetObj)
        {
            return EditorGUILayout.InspectorTitlebar(foldout, targetObj);
        }

        public static bool InspectorTitlebar(bool foldout, UnityEngine.Object targetObj, bool expandable)
        {
            return EditorGUILayout.InspectorTitlebar(foldout, targetObj, expandable);
        }

        public static bool InspectorTitlebar(bool foldout, UnityEngine.Object[] targetObjs)
        {
            return EditorGUILayout.InspectorTitlebar(foldout, targetObjs);
        }

        public static bool InspectorTitlebar(bool foldout, UnityEngine.Object[] targetObjs, bool expandable)
        {
            return EditorGUILayout.InspectorTitlebar(foldout, targetObjs, expandable);
        }

        public static bool InspectorTitlebar(bool foldout, Editor editor)
        {
            return EditorGUILayout.InspectorTitlebar(foldout, editor);
        }

        public static void InspectorTitlebar(UnityEngine.Object[] targetObjs)
        {
            EditorGUILayout.InspectorTitlebar(targetObjs);
        }

        public static void HelpBox(string message, MessageType type)
        {
            EditorGUILayout.HelpBox(message, type);
        }

        public static void HelpBox(string message, MessageType type, bool wide)
        {
            EditorGUILayout.HelpBox(message, type, wide);
        }

        public static void HelpBox(GUIContent content, bool wide)
        {
            EditorGUILayout.HelpBox(content, wide);
        }

        public static void Space()
        {
            EditorGUILayout.Space();
        }

        public static void Separator()
        {
            EditorGUILayout.Separator();
        }

        public static bool BeginToggleGroup(string label, bool toggle)
        {
            return EditorGUILayout.BeginToggleGroup(label, toggle);
        }

        public static bool BeginToggleGroup(GUIContent label, bool toggle)
        {
            return EditorGUILayout.BeginToggleGroup(label, toggle);
        }

        public static void EndToggleGroup()
        {
            EditorGUILayout.EndToggleGroup();
        }

        public static Rect BeginHorizontal(params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginHorizontal(options);
        }

        public static Rect BeginHorizontal(GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginHorizontal(style, options);
        }

        public static void EndHorizontal()
        {
            EditorGUILayout.EndHorizontal();
        }

        public static Rect BeginVertical(params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginVertical(options);
        }

        public static Rect BeginVertical(GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginVertical(style, options);
        }

        public static void EndVertical()
        {
            EditorGUILayout.EndVertical();
        }

        public static Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginScrollView(scrollPosition, options);
        }

        public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginScrollView(scrollPosition, alwaysShowHorizontal, alwaysShowVertical, options);
        }

        public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginScrollView(scrollPosition, horizontalScrollbar, verticalScrollbar, options);
        }

        public static Vector2 BeginScrollView(Vector2 scrollPosition, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginScrollView(scrollPosition, style, options);
        }

        public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options)
        {
            return EditorGUILayout.BeginScrollView
            (
                scrollPosition, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar,
                verticalScrollbar, background, options
            );
        }

        public static void EndScrollView()
        {
            EditorGUILayout.EndScrollView();
        }

        public static bool PropertyField(SerializedProperty property, params GUILayoutOption[] options)
        {
            return EditorGUILayout.PropertyField(property, options);
        }

        public static bool PropertyField(SerializedProperty property, GUIContent label, params GUILayoutOption[] options)
        {
            return EditorGUILayout.PropertyField(property, label, options);
        }

        public static bool PropertyField(SerializedProperty property, bool includeChildren, params GUILayoutOption[] options)
        {
            return EditorGUILayout.PropertyField(property, includeChildren, options);
        }

        public static bool PropertyField(SerializedProperty property, GUIContent label, bool includeChildren, params GUILayoutOption[] options)
        {
            return EditorGUILayout.PropertyField(property, label, includeChildren, options);
        }

        public static Rect GetControlRect(params GUILayoutOption[] options)
        {
            return EditorGUILayout.GetControlRect(options);
        }

        public static Rect GetControlRect(bool hasLabel, params GUILayoutOption[] options)
        {
            return EditorGUILayout.GetControlRect(hasLabel, options);
        }

        public static Rect GetControlRect(bool hasLabel, float height, params GUILayoutOption[] options)
        {
            return EditorGUILayout.GetControlRect(hasLabel, height, options);
        }

        public static Rect GetControlRect(bool hasLabel, float height, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.GetControlRect(hasLabel, height, style, options);
        }

        public static bool BeginFadeGroup(float value)
        {
            return EditorGUILayout.BeginFadeGroup(value);
        }

        public static void EndFadeGroup()
        {
            EditorGUILayout.EndFadeGroup();
        }

        public static bool DropdownButton(GUIContent content, FocusType focusType, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DropdownButton(content, focusType, options);
        }

        public static bool DropdownButton(GUIContent content, FocusType focusType, GUIStyle style, params GUILayoutOption[] options)
        {
            return EditorGUILayout.DropdownButton(content, focusType, style, options);
        }

        public static Gradient GradientField(Gradient value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.GradientField(value, options);
        }

        public static Gradient GradientField(string label, Gradient value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.GradientField(label, value, options);
        }

        public static Gradient GradientField(GUIContent label, Gradient value, params GUILayoutOption[] options)
        {
            return EditorGUILayout.GradientField(label, value, options);
        }

        public static Gradient GradientField(GUIContent label, Gradient value, bool hdr, params GUILayoutOption[] options)
        {
            return EditorGUILayout.GradientField(label, value, hdr, options);
        }

        public static float Knob(Vector2 knobSize, float value, float minValue, float maxValue, string unit, Color backgroundColor, Color activeColor, bool showValue, params GUILayoutOption[] options)
        {
            return EditorGUILayout.Knob
            (
                knobSize, value, minValue, maxValue,
                unit, backgroundColor, activeColor, showValue,
                options
            );
        }

        public static void TextField(GUIContent label, ref string text, GUIStyle style, params GUILayoutOption[] options)
        {
            text = EditorGUILayout.TextField(label, text, style, options);
        }

        public static void TextField(GUIContent label, ref string text, params GUILayoutOption[] options)
        {
            text = EditorGUILayout.TextField(label, text, options);
        }

        public static void TextField(string label, ref string text, GUIStyle style, params GUILayoutOption[] options)
        {
            text = EditorGUILayout.TextField(label, text, style, options);
        }

        public static void TextField(string label, ref string text, params GUILayoutOption[] options)
        {
            text = EditorGUILayout.TextField(label, text, options);
        }

        public static void TextField(ref string text, GUIStyle style, params GUILayoutOption[] options)
        {
            text = EditorGUILayout.TextField(text, style, options);
        }

        public static void TextField(ref string text, params GUILayoutOption[] options)
        {
            text = EditorGUILayout.TextField(text, options);
        }

        #endregion EditorGUILayout

        public static void ChangeCheck(Action beginAction, Action endAction)
        {
            EditorGUI.BeginChangeCheck();
            {
                beginAction.Invoke();
            }
            if (EditorGUI.EndChangeCheck())
            {
                endAction.Invoke();
            }
        }

        public static void BeginChangeCheck()
        {
            EditorGUI.BeginChangeCheck();
        }

        public static bool EndChangeCheck()
        {
            return EditorGUI.EndChangeCheck();
        }

        public static void EndChangeCheck(UnityEngine.Object target)
        {
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(target);
            }
        }

        //public static void FlexibleSpace()
        //{
        //    GUILayout.FlexibleSpace();
        //}

        //public static void Space()
        //{
        //    EditorGUILayout.Space();
        //}

        public static void Label(Rect position, GUIContent content, GUIStyle style)
        {
            GUI.Label(position, content, style);
        }

        public static void Label(Rect position, Texture image, GUIStyle style)
        {
            GUI.Label(position, image, style);
        }

        public static void Label(Rect position, string text, GUIStyle style)
        {
            GUI.Label(position, text, style);
        }

        public static void Label(Rect position, GUIContent content)
        {
            GUI.Label(position, content);
        }

        public static void Label(Rect position, Texture image)
        {
            GUI.Label(position, image);
        }

        public static void Label(Rect position, string text)
        {
            GUI.Label(position, text);
        }

        [ExcludeFromDocs]
        public static void TextField(Rect position, GUIContent label, ref string text)
        {
            text = EditorGUI.TextField(position, label, text);
        }

        public static void TextField(Rect position, string label, ref string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            text = EditorGUI.TextField(position, label, text, style);
        }

        [ExcludeFromDocs]
        public static void TextField(Rect position, string label, ref string text)
        {
            text = EditorGUI.TextField(position, label, text);
        }

        public static void TextField(Rect position, ref string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            text = EditorGUI.TextField(position, text, style);
        }

        [ExcludeFromDocs]
        public static void TextField(Rect position, ref string text)
        {
            text = EditorGUI.TextField(position, text);
        }

        public static void TextField(Rect position, GUIContent label, ref string text, [DefaultValue("EditorStyles.textField")] GUIStyle style)
        {
            text = EditorGUI.TextField(position, label, text, style);
        }

        #endregion UNITY API 重写

        public static void Separator(bool useIndentLevel = false)
        {
            EditorGUILayout.BeginHorizontal();
            if (useIndentLevel)
            {
                GUILayout.Space(EditorGUI.indentLevel * 15);
            }
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
            EditorGUILayout.EndHorizontal();
        }

        public static void Separator(int indentLevel)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(indentLevel * 15);
            GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
            EditorGUILayout.EndHorizontal();
        }

        #region Fields

        private static Color s_ToggleColor;
        private static Color s_ContentColor;
        private static Dictionary<string, GUIStyle> s_Styles;

        #endregion Fields

        #region GUI Controls

        /// <summary>
        /// Creates a toggle button control.
        /// </summary>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <returns>The button state.</returns>
        public static bool Toggle(bool state, GUIContent content)
        {
            PopulateStyles();
            return DoToggle(EditorGUILayout.GetControlRect(), state, content, s_Styles["ToggleOn"], s_Styles["ToggleOff"]);
        }

        /// <summary>
        /// Creates a toggle button control.
        /// </summary>
        /// <param name="rect">The GUI control rect.</param>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <returns>The button state.</returns>
        public static bool Toggle(Rect rect, bool state, GUIContent content)
        {
            PopulateStyles();
            return DoToggle(rect, state, content, s_Styles["ToggleOn"], s_Styles["ToggleOff"]);
        }

        /// <summary>
        /// Creates a toggle button control.
        /// </summary>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <param name="options">GUILayout options.</param>
        /// <returns></returns>
        public static bool Toggle(bool state, GUIContent content, params GUILayoutOption[] options)
        {
            PopulateStyles();
            return DoToggle(EditorGUILayout.GetControlRect(options), state, content, s_Styles["ToggleOn"], s_Styles["ToggleOff"]);
        }

        /// <summary>
        /// Creates a middle toggle button control.
        /// </summary>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <returns>The button state.</returns>
        public static bool ToggleMid(bool state, GUIContent content)
        {
            PopulateStyles();
            return DoToggle(EditorGUILayout.GetControlRect(), state, content, s_Styles["ToggleMidOn"], s_Styles["ToggleMidOff"]);
        }

        /// <summary>
        /// Creates a toggle button control.
        /// </summary>
        /// <param name="rect">The GUI control rect.</param>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <returns>The button state.</returns>
        public static bool ToggleMid(Rect rect, bool state, GUIContent content)
        {
            PopulateStyles();
            return DoToggle(rect, state, content, s_Styles["ToggleMidOn"], s_Styles["ToggleMidOff"]);
        }

        /// <summary>
        /// Creates a middle toggle button control.
        /// </summary>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <param name="options">GUILayout options.</param>
        /// <returns></returns>
        public static bool ToggleMid(bool state, GUIContent content, params GUILayoutOption[] options)
        {
            PopulateStyles();
            return DoToggle(EditorGUILayout.GetControlRect(options), state, content, s_Styles["ToggleMidOn"], s_Styles["ToggleMidOff"]);
        }

        /// <summary>
        /// Creates a left toggle button control.
        /// </summary>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <returns>The button state.</returns>
        public static bool ToggleLeft(bool state, GUIContent content)
        {
            PopulateStyles();
            return DoToggle(EditorGUILayout.GetControlRect(), state, content, s_Styles["ToggleLeftOn"], s_Styles["ToggleLeftOff"]);
        }

        /// <summary>
        /// Creates a toggle button control.
        /// </summary>
        /// <param name="rect">The GUI control rect.</param>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <returns>The button state.</returns>
        public static bool ToggleLeft(Rect rect, bool state, GUIContent content)
        {
            PopulateStyles();
            return DoToggle(rect, state, content, s_Styles["ToggleLeftOn"], s_Styles["ToggleLeftOff"]);
        }

        /// <summary>
        /// Creates a left toggle button control.
        /// </summary>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <param name="options">GUILayout options.</param>
        /// <returns></returns>
        public static bool ToggleLeft(bool state, GUIContent content, params GUILayoutOption[] options)
        {
            PopulateStyles();
            return DoToggle(EditorGUILayout.GetControlRect(options), state, content, s_Styles["ToggleLeftOn"], s_Styles["ToggleLeftOff"]);
        }

        /// <summary>
        /// Creates a right toggle button control.
        /// </summary>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <returns>The button state.</returns>
        public static bool ToggleRight(bool state, GUIContent content)
        {
            PopulateStyles();
            return DoToggle(EditorGUILayout.GetControlRect(), state, content, s_Styles["ToggleRightOn"], s_Styles["ToggleRightOff"]);
        }

        /// <summary>
        /// Creates a toggle button control.
        /// </summary>
        /// <param name="rect">The GUI control rect.</param>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <returns>The button state.</returns>
        public static bool ToggleRight(Rect rect, bool state, GUIContent content)
        {
            PopulateStyles();
            return DoToggle(rect, state, content, s_Styles["ToggleRightOn"], s_Styles["ToggleRightOff"]);
        }

        /// <summary>
        /// Creates a right toggle button control.
        /// </summary>
        /// <param name="state">The toggle state.</param>
        /// <param name="content">GUIContent label.</param>
        /// <param name="options">GUILayout options.</param>
        /// <returns></returns>
        public static bool ToggleRight(bool state, GUIContent content, params GUILayoutOption[] options)
        {
            PopulateStyles();
            return DoToggle(EditorGUILayout.GetControlRect(options), state, content, s_Styles["ToggleRightOn"], s_Styles["ToggleRightOff"]);
        }

        /// <summary>
        /// Creates a toggle button group.
        /// </summary>
        /// <param name="index">The selected button index, or -1.</param>
        /// <param name="content">The GUIContent array for the all buttons.</param>
        /// <returns>The selected index, or -1 when unselected.</returns>
        public static int ToggleGroup(int index, GUIContent[] content)
        {
            PopulateStyles();
            return DoToggleGroup(EditorGUILayout.GetControlRect(), index, content);
        }

        /// <summary>
        /// Creates a toggle button group.
        /// </summary>
        /// <param name="rect">The GUI control rect.</param>
        /// <param name="index">The selected button index, or -1.</param>
        /// <param name="content">The GUIContent array for the all buttons.</param>
        /// <returns>The selected index, or -1 when unselected.</returns>
        public static int ToggleGroup(Rect rect, int index, GUIContent[] content)
        {
            PopulateStyles();
            return DoToggleGroup(rect, index, content);
        }

        #endregion GUI Controls

        private static bool DoToggle(Rect rect, bool state, GUIContent content, GUIStyle on, GUIStyle off)
        {
            if (!state)
            {
                s_ContentColor = GUI.contentColor;
                GUI.contentColor = s_ToggleColor;

                state = GUI.Toggle(rect, state, content, state ? on : off);
                GUI.contentColor = s_ContentColor;

                return state;
            }

            return GUI.Toggle(rect, state, content, state ? on : off);
        }

        private static int DoToggleGroup(Rect rect, int index, GUIContent[] content)
        {
            int count = content.Length;
            rect.width /= count;

            for (int i = 0; i < count; i++)
            {
                rect.x = 4 + i * rect.width;
                bool isSelected = (i == index);

                if (i == 0)
                {
                    if (DoToggle(rect, isSelected, content[i], s_Styles["ToggleLeftOn"], s_Styles["ToggleLeftOff"]) != isSelected)
                    {
                        index = isSelected ? -1 : i;
                    }
                }
                else if (i == count - 1)
                {
                    if (DoToggle(rect, isSelected, content[i], s_Styles["ToggleRightOn"], s_Styles["ToggleRightOff"]) != isSelected)
                    {
                        index = isSelected ? -1 : i;
                    }
                }
                else
                {
                    if (DoToggle(rect, isSelected, content[i], s_Styles["ToggleMidOn"], s_Styles["ToggleMidOff"]) != isSelected)
                    {
                        index = isSelected ? -1 : i;
                    }
                }
            }

            return index;
        }

        private static void PopulateStyles()
        {
            if (s_Styles == null)
            {
                s_ToggleColor = EditorGUIUtility.isProSkin ? new Color(0.75f, 0.75f, 0.75f) : new Color(0.1f, 0.1f, 0.1f);

                s_Styles = new Dictionary<string, GUIStyle>
                {
                    { "ToggleOn", new GUIStyle (EditorStyles.miniButton)      { padding = new RectOffset (2,2,2,2) } },
                    { "ToggleOff",      new GUIStyle (EditorStyles.miniButton)      { padding = new RectOffset (2,2,2,2) } },
                    { "ToggleMidOn",    new GUIStyle (EditorStyles.miniButtonMid)   { padding = new RectOffset (2,2,2,2), margin = new RectOffset (0,0,2,2) } },
                    { "ToggleMidOff",   new GUIStyle (EditorStyles.miniButtonMid)   { padding = new RectOffset (2,2,2,2), margin = new RectOffset (0,0,2,2) } },
                    { "ToggleLeftOn",   new GUIStyle (EditorStyles.miniButtonLeft)  { padding = new RectOffset (2,2,2,2), margin = new RectOffset (4,0,2,2) } },
                    { "ToggleLeftOff",  new GUIStyle (EditorStyles.miniButtonLeft)  { padding = new RectOffset (2,2,2,2), margin = new RectOffset (4,0,2,2) } },
                    { "ToggleRightOn",  new GUIStyle (EditorStyles.miniButtonRight) { padding = new RectOffset (2,2,2,2), margin = new RectOffset (0,4,2,2) } },
                    { "ToggleRightOff", new GUIStyle (EditorStyles.miniButtonRight) { padding = new RectOffset (2,2,2,2), margin = new RectOffset (0,4,2,2) } },
                };

                s_Styles["ToggleOn"].normal.background = s_Styles["ToggleOn"].active.background;
                s_Styles["ToggleMidOn"].normal.background = s_Styles["ToggleMidOn"].active.background;
                s_Styles["ToggleLeftOn"].normal.background = s_Styles["ToggleLeftOn"].active.background;
                s_Styles["ToggleRightOn"].normal.background = s_Styles["ToggleRightOn"].active.background;
            }
        }

        public static void DoReorderableList<TSetting>(TSetting setting, IList list, Type listType, ref UnityEditorInternal.ReorderableList mReorderableList, ref Vector2 mReorderableScrollPosition, ref Vector2 mSettingsScrollPosition, UnityEditorInternal.ReorderableList.ElementCallbackDelegate drawElementCallback = null, Action enableAction = null, Action disableAction = null) where TSetting : ScriptableObject
        {
            if (mReorderableList == null)
            {
                mReorderableList = new UnityEditorInternal.ReorderableList(list, listType, true, false, false, false);
                mReorderableList.headerHeight = 0;
                mReorderableList.showDefaultBackground = false;
                mReorderableList.drawElementCallback = drawElementCallback;
            }
            QuickGUILayoutWrapper.Space();
            using (new QuickEditorGUILayout.HorizontalBlock())
            {
                QuickGUILayoutWrapper.Space();
                if (GUILayout.Button(EditorGUIUtility.FindTexture("Toolbar Plus"), GUIStyle.none, GUILayout.Width(16)))
                {
                    list.Add(Activator.CreateInstance(listType));
                    mReorderableList.index = list.Count - 1;
                    mReorderableList.GrabKeyboardFocus();
                    mSettingsScrollPosition.y = float.MaxValue;
                }
                QuickGUILayoutWrapper.Space();
                if (GUILayout.Button(EditorGUIUtility.FindTexture("Toolbar Minus"), GUIStyle.none, GUILayout.Width(16)))
                {
                    if (mReorderableList.index >= 0 && mReorderableList.index <= list.Count - 1)
                    {
                        Undo.RecordObject(setting, "Removed Import Preset");
                        list.RemoveAt(mReorderableList.index);
                        mReorderableList.index = Mathf.Max(0, mReorderableList.index - 1);
                        mReorderableList.GrabKeyboardFocus();
                    }
                }
                QuickGUILayoutWrapper.FlexibleSpace();
                if (enableAction != null)
                {
                    QuickGUILayoutWrapper.Button("Enable.All", EditorStyles.miniButtonRight, () =>
                    {
                        enableAction();
                    });
                }
                if (disableAction != null)
                {
                    QuickGUILayoutWrapper.Button("Disable.All", EditorStyles.miniButtonLeft, () =>
                    {
                        disableAction();
                    });
                }
            }

            //QEditorGUIStaticAPI.Space();
            QuickGUILayoutWrapper.DrawRect(EditorGUILayout.GetControlRect(false, 2), QuickEditorColors.WhiteCoffee);

            using (var scroll = new EditorGUILayout.ScrollViewScope(mReorderableScrollPosition))
            {
                mReorderableScrollPosition = scroll.scrollPosition;
                mReorderableList.DoLayoutList();
            }
        }

        public static void DrawFoldableBlock(ref bool foldout, string content, Action action)
        {
            using (new QuickEditorGUILayout.FoldableBlock(ref foldout, content))
            {
                if (foldout)
                {
                    if (action != null)
                    {
                        action();
                    }
                }
            }
        }

        public static void Foldout(ref bool foldout, string content, Action action)
        {
            foldout = EditorGUILayout.Foldout(foldout, content);
            if (foldout)
            {
                using (new QuickEditorGUILayout.VerticalBlock(new GUIStyle() { padding = new RectOffset(20, 0, 0, 0) }))
                {
                    if (action != null)
                    {
                        action();
                    }
                }
            }
        }

        public static void IndentBlock(Action action)
        {
            using (new QuickEditorGUILayout.IndentBlock())
            {
                if (action != null)
                {
                    action();
                }
            }
        }

        public static void DrawRect(Rect rect, Color color)
        {
            EditorGUI.DrawRect(rect, color);
        }

        public static void DisabledGroup(bool disabled, Action action)
        {
            EditorGUI.BeginDisabledGroup(disabled);
            if (action != null)
            {
                action();
            }
            EditorGUI.EndDisabledGroup();
        }

        public static void EnumPopup<TEnum>(Rect position, Enum selected, ref TEnum finalEnum) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(TEnum).IsEnum) { throw new ArgumentException("TEnum must be an enumerated type"); }
            var @enum = EditorGUI.EnumPopup(position, selected);
            finalEnum = (TEnum)Convert.ChangeType(@enum, typeof(TEnum));
        }

        public static void EnumPopup<TEnum>(string label, Enum selected, ref TEnum finalEnum, params GUILayoutOption[] options) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(TEnum).IsEnum) { throw new ArgumentException("TEnum must be an enumerated type"); }
            var @enum = EditorGUILayout.EnumPopup(label, selected, options);
            finalEnum = (TEnum)Convert.ChangeType(@enum, typeof(TEnum));
        }

        public static TEnum EnumPopup<TEnum>(string label, Enum selected) where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            if (!typeof(TEnum).IsEnum) { throw new ArgumentException("TEnum must be an enumerated type"); }
            var @enum = EditorGUILayout.EnumPopup(label, selected);
            return (TEnum)Convert.ChangeType(@enum, typeof(TEnum));
        }

        public static Rect DrawLeftRect(Rect rect, Action action)
        {
            Rect topLeftPane = new Rect(rect);
            topLeftPane.width = Mathf.Ceil(rect.width * 0.333333f);
            EditorGUI.DrawRect(topLeftPane, QuickEditorColors.WhiteChocolate);

            GUILayout.BeginArea(topLeftPane);
            if (action != null)
            {
                action();
            }
            GUILayout.EndArea();
            return topLeftPane;
        }

        public static void DrawRightRect(Rect rect, Rect leftRect, Action action)
        {
            Rect rightPane = new Rect(rect);
            rightPane.width = Mathf.Ceil((rect.width * 0.666666f)) - 3;
            rightPane.x = leftRect.xMax + 3;
            EditorGUI.DrawRect(rightPane, QuickEditorColors.WhiteChocolate);

            Rect rightPaneGUI = rightPane;
            rightPaneGUI.x += 4;
            rightPaneGUI.width -= 8;
            GUILayout.BeginArea(rightPaneGUI);
            if (action != null)
            {
                action();
            }
            GUILayout.EndArea();
        }

        public static int Toolbar(ref int selected, GUIContent[] contents, GUIStyle style, params GUILayoutOption[] options)
        {
            return selected = GUILayout.Toolbar(selected, contents, style, options);
        }

        public static int Toolbar(ref int selected, string[] texts, GUIStyle style, params GUILayoutOption[] options)
        {
            return selected = GUILayout.Toolbar(selected, texts, style, options);
        }

        public static int Toolbar(ref int selected, string[] texts, params GUILayoutOption[] options)
        {
            return selected = GUILayout.Toolbar(selected, texts, options);
        }

        public static int Toolbar(ref int selected, Texture[] images, params GUILayoutOption[] options)
        {
            return selected = GUILayout.Toolbar(selected, images, options);
        }

        public static int Toolbar(ref int selected, GUIContent[] content, params GUILayoutOption[] options)
        {
            return selected = GUILayout.Toolbar(selected, content, options);
        }

        public static int Toolbar(ref int selected, Texture[] images, GUIStyle style, params GUILayoutOption[] options)
        {
            return selected = GUILayout.Toolbar(selected, images, style, options);
        }

        public static void Toggle(string label, ref bool value, params GUILayoutOption[] options)
        {
            value = EditorGUILayout.Toggle(label, value);
        }

        public static void ToggleButton(string label, ref bool value, params GUILayoutOption[] options)
        {
            value = GUILayout.Toggle(value, label, EditorStyles.miniButton, options);
        }

        public static string SearchField(string searchStr, params GUILayoutOption[] options)
        {
            searchStr = GUILayout.TextField(searchStr, "ToolbarSeachTextField", options);
            if (GUILayout.Button("", "ToolbarSeachCancelButton"))
            {
                searchStr = "";
                GUI.FocusControl(null);
            }
            return searchStr;
        }

        public static void DrawSelectButton(GameObject obj)
        {
            GUI.backgroundColor = Color.green;
            if (GUILayout.Button("Select", GUILayout.MinWidth(80), GUILayout.MaxWidth(80)))
            {
                Selection.objects = new UnityEngine.Object[] { obj };
            }
            GUI.backgroundColor = Color.white;
        }

        public static bool DrawDeleteButton()
        {
            GUI.backgroundColor = Color.red;
            bool result = GUILayout.Button("X", GUILayout.MinWidth(30), GUILayout.MaxWidth(30));
            GUI.backgroundColor = Color.white;
            return result;
        }

        public static void ColorButton(string text, Color color, Action callback, params GUILayoutOption[] options)
        {
            GUI.backgroundColor = color;
            if (GUILayout.Button(text, options))
            {
                callback();
            }
            GUI.backgroundColor = Color.white;
        }

        public static void ColorButton(GUIContent content, Color color, Action callback, params GUILayoutOption[] options)
        {
            GUI.backgroundColor = color;
            if (GUILayout.Button(content, options))
            {
                callback();
            }
            GUI.backgroundColor = Color.white;
        }

        public static void DragAndDropTextField(string name, ref string path, params GUILayoutOption[] options)
        {
            using (new QuickEditorGUILayout.HorizontalBlock())
            {
                Rect rect = EditorGUILayout.GetControlRect(options);
                path = EditorGUI.TextField(rect, name, path);
                if ((Event.current.type == EventType.DragUpdated ||
                    Event.current.type == EventType.DragExited) &&
                rect.Contains(Event.current.mousePosition))
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                    if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)
                    {
                        path = DragAndDrop.paths[0];
                    }
                }
            }
        }

        public static void FileTextField(string name, ref string path, string title, string extension, string buttonName = "Browse", params GUILayoutOption[] options)
        {
            using (new QuickEditorGUILayout.HorizontalBlock(options))
            {
                path = EditorGUILayout.TextField(name, path);
                if (GUILayout.Button(EditorGUIUtility.FindTexture("project"), EditorStyles.label))
                {
                    string selectStr = EditorUtility.OpenFilePanel(title, path, extension);
                    if (!string.IsNullOrEmpty(selectStr) && selectStr.Contains("Assets"))
                    {
                        path = selectStr;
                    }
                }
            }
        }

        public static void FileTextField(Rect position, string name, ref string path, string title, string extension, params GUILayoutOption[] options)
        {
            using (new QuickEditorGUILayout.HorizontalBlock(options))
            {
                var rect = position;
                rect.width -= 14;
                path = EditorGUI.TextField(rect, name, path);
                var btnRect = new Rect(rect.x + rect.width - 1, rect.y, 20, 17);
                if (GUI.Button(btnRect, EditorGUIUtility.FindTexture("project"), EditorStyles.label))
                {
                    string currentDirectory = path;
                    if (string.IsNullOrEmpty(path))
                    {
                        currentDirectory = QuickPathUtils.AssetsRootDir;
                    }
                    string selectStr = EditorUtility.OpenFilePanel(title, currentDirectory, extension);
                    if (!string.IsNullOrEmpty(selectStr) && selectStr.Contains("Assets"))
                    {
                        path = selectStr;
                    }
                }
            }
        }

        public static void FileTextField(string name, ref string path, string title, string extension, params GUILayoutOption[] options)
        {
            using (new QuickEditorGUILayout.HorizontalBlock(options))
            {
                var rect = GUILayoutUtility.GetRect(new GUIContent("buttonName"), EditorStyles.textField, options);
                rect.width -= 14;
                path = EditorGUI.TextField(rect, name, path);
                var btnRect = new Rect(rect.x + rect.width - 1, rect.y, 20, 17);
                if (GUI.Button(btnRect, EditorGUIUtility.FindTexture("project"), EditorStyles.label))
                {
                    string currentDirectory = path;
                    if (string.IsNullOrEmpty(currentDirectory)) { currentDirectory = Directory.GetCurrentDirectory(); }
                    string selectStr = EditorUtility.OpenFilePanel(title, currentDirectory, extension);
                    path = selectStr;
                    //if (!string.IsNullOrEmpty(selectStr) && selectStr.Contains("Assets"))
                    //{
                    //    path = selectStr;
                    //}
                }
            }
        }

        public static string FileLabel(string title, string directory, string extension, params GUILayoutOption[] options)
        {
            using (new QuickEditorGUILayout.HorizontalBlock(options))
            {
                GUILayout.Label(title, GUILayout.ExpandWidth(true));
                var filepath = EditorGUILayout.TextField(directory);

                if (GUILayout.Button("Browse", EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
                    filepath = EditorUtility.OpenFilePanel(title, directory, extension);

                return filepath;
            }
        }

        public static string FolderLabel(string name, float labelWidth, string path, params GUILayoutOption[] options)
        {
            using (new QuickEditorGUILayout.HorizontalBlock(options))
            {
                var filepath = EditorGUILayout.TextField(name, path, GUILayout.ExpandWidth(true));
                if (GUILayout.Button("Browse", EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
                {
                    filepath = EditorUtility.SaveFolderPanel(name, path, "Folder");
                }
                return filepath;
            }
        }

        public static bool CtrlLeftClickOnRect(Rect rect)
        {
            if (
                Event.current.button == 0
                && Event.current.control == true
                && Event.current.shift == false
                && Event.current.alt == false
                && rect.Contains(Event.current.mousePosition))
            {
                return true;
            }

            return false;
        }

        public static bool AltLeftClickOnRect(Rect rect)
        {
            if (
                Event.current.button == 0
                && Event.current.control == false
                && Event.current.shift == false
                && Event.current.alt == true
                && rect.Contains(Event.current.mousePosition))
            {
                return true;
            }

            return false;
        }

        public static bool ShiftLeftClickOnRect(Rect rect)
        {
            if (
                Event.current.button == 0
                && Event.current.control == false
                && Event.current.shift == true
                && Event.current.alt == false
                && rect.Contains(Event.current.mousePosition))
            {
                return true;
            }
            return false;
        }

        public static bool RightClickOnRect(Rect rect)
        {
            if (
                Event.current.button == 1
                && Event.current.control == false
                && Event.current.shift == false
                && Event.current.alt == false
                && rect.Contains(Event.current.mousePosition))
            {
                return true;
            }
            return false;
        }

        public static bool LeftClickOnRect(Rect rect)
        {
            if (
                Event.current.button == 0
                && Event.current.control == false
                && Event.current.shift == false
                && Event.current.alt == false
                && rect.Contains(Event.current.mousePosition))
            {
                return true;
            }
            return false;
        }

        public static bool CtrlRightClickOnRect(Rect rect)
        {
            if (
                Event.current.button == 1
                && Event.current.control == true
                && Event.current.shift == false
                && Event.current.alt == false
                && rect.Contains(Event.current.mousePosition))
            {
                return true;
            }
            return false;
        }

        public static bool CtrlShiftRightClickOnRect(Rect rect)
        {
            if (
                Event.current.button == 1
                && Event.current.control == true
                && Event.current.shift == true
                && Event.current.alt == false
                && rect.Contains(Event.current.mousePosition))
            {
                return true;
            }

            return false;
        }

        public static bool ScrollWheelClickOnRect(Rect rect)
        {
            if (
                Event.current.button == 2
                && Event.current.control == false
                && Event.current.shift == false
                && Event.current.alt == false
                && rect.Contains(Event.current.mousePosition))
            {
                return true;
            }

            return false;
        }

        public static bool LayoutToggleSwitch(GUIContent[] labels, bool state, params GUILayoutOption[] options)
        {
            int i;
            if (state == true)
            {
                i = 0;
                i = GUILayout.Toolbar(i, labels, options);
            }
            else
            {
                i = 1;
                i = GUILayout.Toolbar(i, labels, options);
            }

            return i == 0;
        }

        [ExcludeFromDocs]
        public static bool LayoutToggleSwitch(GUIContent[] labels, bool state, GUIStyle style, params GUILayoutOption[] options)
        {
            int i;
            if (state == true)
            {
                i = 0;
                i = GUILayout.Toolbar(i, labels, style, options);
            }
            else
            {
                i = 1;
                i = GUILayout.Toolbar(i, labels, style, options);
            }

            return i == 0;
        }

        [ExcludeFromDocs]
        public static bool LayoutToggleSwitch(string[] labels, bool state, params GUILayoutOption[] options)
        {
            int i;
            if (state == true)
            {
                i = 0;
                i = GUILayout.Toolbar(i, labels, options);
            }
            else
            {
                i = 1;
                i = GUILayout.Toolbar(i, labels, options);
            }

            return i == 0;
        }

        [ExcludeFromDocs]
        public static bool LayoutToggleSwitch(string[] labels, bool state, GUIStyle style, params GUILayoutOption[] options)
        {
            int i;
            if (state == true)
            {
                i = 0;
                i = GUILayout.Toolbar(i, labels, style, options);
            }
            else
            {
                i = 1;
                i = GUILayout.Toolbar(i, labels, style, options);
            }

            return i == 0;
        }
    }
}