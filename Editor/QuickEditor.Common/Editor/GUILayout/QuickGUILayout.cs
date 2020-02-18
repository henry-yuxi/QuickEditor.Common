namespace QuickEditor.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.Internal;

    public static class QuickGUILayout
    {
        #region UNITY API 重写

        #region 重写GUILayout.Button

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

        #endregion 重写GUILayout.Button

        #region 重写EditorGUILayout.TextField

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

        #endregion 重写EditorGUILayout.TextField

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

        public static void FlexibleSpace()
        {
            GUILayout.FlexibleSpace();
        }

        public static void Space()
        {
            EditorGUILayout.Space();
        }

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
            QuickGUILayout.Space();
            using (new QuickEditorGUILayout.HorizontalBlock())
            {
                QuickGUILayout.Space();
                if (GUILayout.Button(EditorGUIUtility.FindTexture("Toolbar Plus"), GUIStyle.none, GUILayout.Width(16)))
                {
                    list.Add(Activator.CreateInstance(listType));
                    mReorderableList.index = list.Count - 1;
                    mReorderableList.GrabKeyboardFocus();
                    mSettingsScrollPosition.y = float.MaxValue;
                }
                QuickGUILayout.Space();
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
                QuickGUILayout.FlexibleSpace();
                if (enableAction != null)
                {
                    QuickGUILayout.Button("Enable.All", EditorStyles.miniButtonRight, () =>
                    {
                        enableAction();
                    });
                }
                if (disableAction != null)
                {
                    QuickGUILayout.Button("Disable.All", EditorStyles.miniButtonLeft, () =>
                    {
                        disableAction();
                    });
                }
            }

            //QEditorGUIStaticAPI.Space();
            QuickGUILayout.DrawRect(EditorGUILayout.GetControlRect(false, 2), QuickEditorColors.WhiteCoffee);

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