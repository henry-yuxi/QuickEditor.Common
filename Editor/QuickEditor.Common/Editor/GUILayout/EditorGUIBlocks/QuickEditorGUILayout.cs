namespace QuickEditor.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;

    public sealed class QuickEditorGUILayout
    {
        public sealed class AreaBlock : IDisposable
        {
            public AreaBlock(Rect screenRect)
            {
                GUILayout.BeginArea(screenRect);
            }

            public AreaBlock(Rect screenRect, string text)
            {
                GUILayout.BeginArea(screenRect, text);
            }

            public AreaBlock(Rect screenRect, Texture image)
            {
                GUILayout.BeginArea(screenRect, image);
            }

            public AreaBlock(Rect screenRect, GUIContent content)
            {
                GUILayout.BeginArea(screenRect, content);
            }

            public AreaBlock(Rect screenRect, GUIStyle style)
            {
                GUILayout.BeginArea(screenRect, style);
            }

            public AreaBlock(Rect screenRect, string text, GUIStyle style)
            {
                GUILayout.BeginArea(screenRect, text, style);
            }

            public AreaBlock(Rect screenRect, Texture image, GUIStyle style)
            {
                GUILayout.BeginArea(screenRect, image, style);
            }

            public AreaBlock(Rect screenRect, GUIContent content, GUIStyle style)
            {
                GUILayout.BeginArea(screenRect, content, style);
            }

            public void Dispose()
            {
                GUILayout.EndArea();
            }
        }

        public sealed class BackgroundColorBlock : GUI.Scope
        {
            private readonly Color mColor;

            public BackgroundColorBlock(Color color)
            {
                this.mColor = GUI.backgroundColor;
                GUI.backgroundColor = color;
            }

            protected override void CloseScope()
            {
                GUI.backgroundColor = mColor;
            }
        }

        public sealed class ColorBlock : GUI.Scope
        {
            private readonly Color mSavedColor;

            public ColorBlock(Color newColor)
            {
                mSavedColor = GUI.backgroundColor;
                GUI.color = newColor;
            }

            protected override void CloseScope()
            {
                GUI.color = mSavedColor;
            }
        }

        public sealed class ColoredBlock : GUI.Scope
        {
            public ColoredBlock(Color color)
            {
                GUI.color = color;
            }

            protected override void CloseScope()
            {
                GUI.color = Color.white;
            }
        }

        public sealed class DisabledBlock : GUI.Scope
        {
            public DisabledBlock(bool state)
            {
                GUI.enabled = state;
            }

            protected override void CloseScope()
            {
                GUI.enabled = true;
            }
        }

        public sealed class DisabledGroupBlock : IDisposable
        {
            public DisabledGroupBlock(bool disabled)
            {
                EditorGUI.BeginDisabledGroup(disabled);
            }

            public void Dispose()
            {
                EditorGUI.EndDisabledGroup();
            }
        }

        public sealed class FadeGroupBlock : GUI.Scope
        {
            public FadeGroupBlock(float value, ref bool isVisible)
            {
                isVisible = EditorGUILayout.BeginFadeGroup(value);
            }

            protected override void CloseScope()
            {
                EditorGUILayout.EndFadeGroup();
            }
        }

        public sealed class FoldableBlock : GUI.Scope
        {
            private readonly Color _defaultBackgroundColor;

            private bool _expanded;

            public FoldableBlock(ref bool expanded, string header) : this(ref expanded, header, null)
            {
            }

            public FoldableBlock(ref bool expanded, string header, Texture2D icon)
            {
                _defaultBackgroundColor = GUI.backgroundColor;
                GUILayout.Space(3f);
                GUILayout.BeginHorizontal();
                GUILayout.Space(3f);
                GUI.changed = false;
                //expanded = EditorGUILayout.Foldout(expanded, new GUIContent("<b><size=12>" + header + "</size></b>", icon), "dragtab");

                if (!GUILayout.Toggle(true, new GUIContent("<b><size=12>" + header + "</size></b>", icon), "dragtab"))
                    expanded = !expanded;
                GUILayout.Space(2f);
                GUILayout.EndHorizontal();
                if (!expanded)
                {
                    GUILayout.Space(3f);
                }
                else
                {
                    GroupStart();
                }
                _expanded = expanded;
            }

            private void GroupStart()
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(4f);
                EditorGUILayout.BeginHorizontal("AS TextArea", GUILayout.MinHeight(10f));
                GUILayout.BeginVertical();
                GUILayout.Space(2f);
            }

            private void GroupEnd()
            {
                GUILayout.Space(3f);
                GUILayout.EndVertical();
                EditorGUILayout.EndHorizontal();
                GUILayout.Space(3f);
                GUILayout.EndHorizontal();
                GUILayout.Space(3f);
                GUI.backgroundColor = _defaultBackgroundColor;
            }

            protected override void CloseScope()
            {
                if (_expanded)
                    GroupEnd();
            }
        }

        public sealed class IndentBlock : GUI.Scope
        {
            private int indent = 1;

            public IndentBlock()
            {
                EditorGUI.indentLevel += indent;
            }

            public IndentBlock(int level)
            {
                indent = level;
                EditorGUI.indentLevel += indent;
            }

            protected override void CloseScope()
            {
                EditorGUI.indentLevel -= indent;
            }
        }

        public sealed class HorizontalBlock : GUI.Scope
        {
            public HorizontalBlock(params GUILayoutOption[] options)
            {
                GUILayout.BeginHorizontal(options);
            }

            public HorizontalBlock(GUIStyle style, params GUILayoutOption[] options)
            {
                GUILayout.BeginHorizontal(style, options);
            }

            protected override void CloseScope()
            {
                GUILayout.EndHorizontal();
            }
        }

        public sealed class VerticalBlock : GUI.Scope
        {
            public VerticalBlock(params GUILayoutOption[] options)
            {
                EditorGUILayout.BeginVertical(options);
            }

            public VerticalBlock(GUIStyle style, params GUILayoutOption[] options)
            {
                EditorGUILayout.BeginVertical(style, options);
            }

            protected override void CloseScope()
            {
                EditorGUILayout.EndVertical();
            }
        }

        public sealed class VerticalGroupBlock : GUI.Scope
        {
            private static GUIStyle styleHeader;
            private static GUIStyle styleInner;

            private static void CacheGUI()
            {
                if (styleHeader != null)
                    return;

                styleHeader = new GUIStyle("RL Header");
                styleHeader.alignment = TextAnchor.MiddleLeft;
                styleHeader.richText = true;
                styleHeader.fontSize = 11;
                styleHeader.fontStyle = FontStyle.Bold;
                styleHeader.stretchWidth = true;
                styleHeader.margin = new RectOffset(4, 0, 2, 0);
                styleHeader.padding = new RectOffset(6, 4, 0, 0);
                styleHeader.stretchWidth = true;
                styleHeader.stretchHeight = false;
                styleHeader.normal.textColor = EditorStyles.label.normal.textColor;

                styleInner = new GUIStyle("RL Background");
                styleInner.border = new RectOffset(10, 10, 1, 8);
                styleInner.margin = new RectOffset(4, 0, 0, 2);
                styleInner.padding = new RectOffset(4, 4, 3, 6);
                styleInner.clipping = TextClipping.Clip;
            }

            private void SetScope(GUIContent content, params GUILayoutOption[] option)
            {
                CacheGUI();

                Rect r = GUILayoutUtility.GetRect(18, 18, styleHeader);
                GUI.Label(r, content, styleHeader);

                Color backgroundColor = GUI.backgroundColor;
                GUI.backgroundColor = Color.white;
                EditorGUILayout.BeginVertical(styleInner, option);
                GUI.backgroundColor = backgroundColor;
            }

            public VerticalGroupBlock(string text, params GUILayoutOption[] option)
            {
                SetScope(new GUIContent(text), option);
            }

            protected override void CloseScope()
            {
                EditorGUILayout.EndVertical();
            }
        }

        public sealed class HighlightBox : GUI.Scope
        {
            public HighlightBox() : this(new Color(0.1f, 0.1f, 0.2f))
            {
            }

            public HighlightBox(Color color)
            {
                GUILayout.Space(8f);
                GUILayout.BeginHorizontal();
                GUILayout.Space(4f);
                using (new ColorBlock(color))
                {
                    EditorGUILayout.BeginHorizontal(EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).GetStyle("sv_iconselector_labelselection"), GUILayout.MinHeight(10f));
                }
                GUILayout.BeginVertical();
                GUILayout.Space(4f);
            }

            protected override void CloseScope()
            {
                GUILayout.Space(3f);
                GUILayout.EndVertical();
                EditorGUILayout.EndHorizontal();
                GUILayout.Space(3f);
                GUILayout.EndHorizontal();
                GUILayout.Space(3f);
            }
        }

        public sealed class ScrollViewBlock : GUI.Scope
        {
            public ScrollViewBlock(ref Vector2 scrollPos, params GUILayoutOption[] options)
            {
                scrollPos = GUILayout.BeginScrollView(scrollPos, options);
            }

            public ScrollViewBlock(ref Vector2 scrollPos, bool alwaysShowHorizontal, bool alwaysShowVertical, params GUILayoutOption[] options)
            {
                scrollPos = GUILayout.BeginScrollView(scrollPos, alwaysShowHorizontal, alwaysShowVertical, options);
            }

            public ScrollViewBlock(ref Vector2 scrollPos, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, params GUILayoutOption[] options)
            {
                scrollPos = GUILayout.BeginScrollView(scrollPos, horizontalScrollbar, verticalScrollbar, options);
            }

            public ScrollViewBlock(ref Vector2 scrollPos, GUIStyle style, params GUILayoutOption[] options)
            {
                scrollPos = GUILayout.BeginScrollView(scrollPos, style, options);
            }

            public ScrollViewBlock(ref Vector2 scrollPos, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options)
            {
                scrollPos = GUILayout.BeginScrollView(scrollPos, alwaysShowHorizontal, alwaysShowVertical, horizontalScrollbar, verticalScrollbar, background, options);
            }

            protected override void CloseScope()
            {
                GUILayout.EndScrollView();
            }
        }

        public class SplitViewBlock
        {
            public enum Direction
            {
                Horizontal,
                Vertical
            }

            private Direction splitDirection;
            private float splitNormalizedPosition;
            private bool resize;
            public Vector2 scrollPosition;
            private Rect availableRect;

            public SplitViewBlock(Direction splitDirection)
            {
                splitNormalizedPosition = 0.35f;
                this.splitDirection = splitDirection;
            }

            public void BeginSplitView()
            {
                Rect tempRect;

                if (splitDirection == Direction.Horizontal)
                    tempRect = EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                else
                    tempRect = EditorGUILayout.BeginVertical(GUILayout.ExpandHeight(true));

                if (tempRect.width > 0.0f)
                {
                    availableRect = tempRect;
                }
                if (splitDirection == Direction.Horizontal)
                    scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(availableRect.width * splitNormalizedPosition));
                else
                    scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(availableRect.height * splitNormalizedPosition));
            }

            public void Split()
            {
                GUILayout.EndScrollView();
                ResizeSplitFirstView();
            }

            public void EndSplitView()
            {
                if (splitDirection == Direction.Horizontal)
                    EditorGUILayout.EndHorizontal();
                else
                    EditorGUILayout.EndVertical();
            }

            private void ResizeSplitFirstView()
            {
                Rect resizeHandleRect;

                if (splitDirection == Direction.Horizontal)
                    resizeHandleRect = new Rect(availableRect.width * splitNormalizedPosition, availableRect.y, 2f, availableRect.height);
                else
                    resizeHandleRect = new Rect(availableRect.x, availableRect.height * splitNormalizedPosition, availableRect.width, 2f);

                GUI.DrawTexture(resizeHandleRect, EditorGUIUtility.whiteTexture);

                if (splitDirection == Direction.Horizontal)
                    EditorGUIUtility.AddCursorRect(resizeHandleRect, MouseCursor.ResizeHorizontal);
                else
                    EditorGUIUtility.AddCursorRect(resizeHandleRect, MouseCursor.ResizeVertical);

                if (Event.current.type == EventType.MouseDown && resizeHandleRect.Contains(Event.current.mousePosition))
                {
                    resize = true;
                }
                if (resize)
                {
                    if (splitDirection == Direction.Horizontal)
                        splitNormalizedPosition = Event.current.mousePosition.x / availableRect.width;
                    else
                        splitNormalizedPosition = Event.current.mousePosition.y / availableRect.height;
                }
                if (Event.current.type == EventType.MouseUp)
                    resize = false;
            }
        }

        public sealed class ToggleGroupBlock : GUI.Scope
        {
            public ToggleGroupBlock(GUIContent label, ref bool toggle)
            {
                toggle = EditorGUILayout.BeginToggleGroup(label, toggle);
            }

            public ToggleGroupBlock(string label, ref bool toggle)
            {
                toggle = EditorGUILayout.BeginToggleGroup(label, toggle);
            }

            protected override void CloseScope()
            {
                EditorGUILayout.EndToggleGroup();
            }
        }

        public sealed class OrientationBlock : GUI.Scope
        {
            public enum Orientation
            {
                Horizontal,
                Vertical
            }

            private readonly Orientation _orientation;

            public OrientationBlock(Orientation orientation, string style, params GUILayoutOption[] options)
            {
                _orientation = orientation;
                if (orientation == Orientation.Horizontal)
                {
                    EditorGUILayout.BeginHorizontal(string.IsNullOrEmpty(style) ? GUIStyle.none : style, options);
                }
                else
                {
                    EditorGUILayout.BeginVertical(string.IsNullOrEmpty(style) ? GUIStyle.none : style, options);
                }
            }

            public OrientationBlock(Orientation orientation, string style) : this(orientation, style, new GUILayoutOption[] { })
            {
            }

            public OrientationBlock(Orientation orientation) : this(orientation, null, new GUILayoutOption[] { })
            {
            }

            protected override void CloseScope()
            {
                if (_orientation == Orientation.Horizontal)
                {
                    EditorGUILayout.EndHorizontal();
                }
                else
                {
                    EditorGUILayout.EndVertical();
                }
            }
        }

        [Serializable]
        public sealed class TabsBlock
        {
            private readonly Dictionary<string, Action> _methods;
            private Action _currentGuiMethod;
            public int CurMethodIndex = -1;

            public TabsBlock(Dictionary<string, Action> _methods)
            {
                this._methods = _methods;
                SetCurrentMethod(0);
            }

            public void DrawTabs()
            {
                var keys = _methods.Keys.ToArray();
                using (new HorizontalBlock())
                {
                    for (var i = 0; i < keys.Length; i++)
                    {
                        var btnStyle = i == 0
                            ? EditorStyles.miniButtonLeft
                            : i == (keys.Length - 1)
                                ? EditorStyles.miniButtonRight
                                : EditorStyles.miniButtonMid;

                        using (new ColoredBlock(_currentGuiMethod == _methods[keys[i]] ? Color.grey : Color.white))
                            if (GUILayout.Button(keys[i], btnStyle))
                                SetCurrentMethod(i);
                    }
                }
            }

            public void DrawBody(GUIStyle backgroundStyle)
            {
                using (new VerticalBlock(backgroundStyle))
                {
                    var keys = _methods.Keys.ToArray();
                    GUILayout.Label(keys[CurMethodIndex], EditorStyles.centeredGreyMiniLabel);
                    _currentGuiMethod();
                }
            }

            public void SetCurrentMethod(int index)
            {
                CurMethodIndex = index;
                _currentGuiMethod = _methods[_methods.Keys.ToArray()[index]];
            }
        }
    }
}