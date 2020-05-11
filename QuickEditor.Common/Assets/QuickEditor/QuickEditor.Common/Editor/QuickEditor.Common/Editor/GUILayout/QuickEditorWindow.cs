#if UNITY_EDITOR

namespace QuickEditor.Common
{
    using UnityEditor;
    using UnityEngine;

    public class QEditorHorizontalSplitWindow : QuickEditorWindow
    {
        private QuickEditorGUILayout.SplitViewBlock horizontalSplitView = new QuickEditorGUILayout.SplitViewBlock(QuickEditorGUILayout.SplitViewBlock.Direction.Horizontal);

        protected override void OnGUI()
        {
            base.OnGUI();
            horizontalSplitView.BeginSplitView();
            DrawLeftRect();
            horizontalSplitView.Split();
            DrawRightRect();
            horizontalSplitView.EndSplitView();
        }

        protected virtual void DrawRightRect()
        {
        }

        protected virtual void DrawLeftRect()
        {
        }
    }

    public class QuickEditorWindow : EditorWindow
    {
        protected static string WindowTitle;
        protected static Vector2 WindowRect = new Vector2(600, 500);

        public static T GetEditorWindow<T>() where T : EditorWindow
        {
            return GetEditorWindow<T>(false, true);
        }

        public static T GetEditorWindow<T>(bool utility) where T : EditorWindow
        {
            return GetEditorWindow<T>(utility, true);
        }

        public static T GetEditorWindow<T>(bool utility, bool focus) where T : EditorWindow
        {
            return GetWindow<T>(utility, WindowTitle, focus)
                .minSize(WindowRect) as T;
        }

        /// <summary>
        /// 是否启用标题UI
        /// </summary>
        protected virtual bool IsEnableTitleGUI { get { return true; } }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Initialization()
        {
        }

        /// <summary>
        /// 标题UI
        /// </summary>
        protected virtual void OnTitleGUI()
        {
        }

        /// <summary>
        /// 窗体UI
        /// </summary>
        protected virtual void OnBodyGUI()
        {
        }

        /// <summary>
        /// 当打开界面的时候调用
        /// </summary>
        protected virtual void OnEnable()
        {
        }

        /// <summary>
        /// 当被聚焦的时候调用
        /// </summary>
        protected virtual void OnFocus()
        {
        }

        /// <summary>
        /// 当属性界面更新时，几乎一直在更新
        /// </summary>
        protected virtual void OnInspectorUpdate()
        {
            this.Repaint();
        }

        /// <summary>
        /// 当项目发生更改时调用");//在Project视图删除、增加文件
        /// </summary>
        protected virtual void OnProjectChange()
        {
        }

        /// <summary>
        /// 当选择发生更改时调用，选中的可选项（在Project和Hierarchy视图中）
        /// </summary>
        protected virtual void OnSelectionChange()
        {
        }

        /// <summary>
        /// 当场景层次界面发生改变时调用");//在Hierarchy界面改变（增加、减少物体）
        /// </summary>
        protected virtual void OnHierarchyChange()
        {
        }

        /// <summary>
        /// 当渲染UI的时候调用 持续触发
        /// </summary>
        protected virtual void OnGUI()
        {
            if (IsEnableTitleGUI)
            {
                GUILayout.BeginHorizontal(EditorStyles.toolbar);
                OnTitleGUI();
                GUILayout.EndHorizontal();
            }

            OnBodyGUI();
        }

        /// <summary>
        /// 当失去焦点时调用
        /// </summary>
        protected virtual void OnLostFocus()
        {
        }

        /// <summary>
        /// 当隐藏的时候调用
        /// </summary>
        protected virtual void OnDisable()
        {
        }

        /// <summary>
        /// 当销毁的时候调用
        /// </summary>
        protected virtual void OnDestroy()
        {
        }

        /// <summary>
        /// 标记目标已改变
        /// </summary>
        protected void HasChanged(Object target)
        {
            if (!EditorApplication.isPlaying && target != null)
            {
                EditorUtility.SetDirty(target);
                Component comp = target as Component;
                if (comp != null && comp.gameObject.scene != null)
                {
                    UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(comp.gameObject.scene);
                }
            }
        }
    }
}

#endif