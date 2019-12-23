#if UNITY_EDITOR

namespace QuickEditor.Common
{
    using UnityEditor;
    using UnityEngine;

    public class QuickScriptableWizard : ScriptableWizard
    {
        protected static string WindowTitle;
        protected static Vector2 WindowRect = new Vector2(600, 500);

        public static T GetScriptableWizard<T>() where T : EditorWindow
        {
            return GetWindow<T>(WindowTitle, false)
                    .minSize(WindowRect) as T;
        }

        /// <summary>
        /// 两个按钮事件中的一个，当传入ScriptableWizard.DisplayWizard函数中"createButtonName"参数对应的按钮被点击时调用。
        /// </summary>
        protected virtual void OnWizardCreate()
        {
        }

        /// <summary>
        /// 两个按钮事件中的一个，当传入ScriptableWizard.DisplayWizard函数中"otherButtonName"参数对应的按钮被点击时调用。
        /// </summary>
        protected virtual void OnWizardOtherButton()
        {
        }

        /// <summary>
        /// 当向导窗口打开时或者用户改变窗口内容时都会被调用。一般会在这里显示帮助文字和进行内容有效性验证。也可以动态改变按钮状态。
        /// </summary>
        protected virtual void OnWizardUpdate()
        {
        }

        /// <summary>
        /// 当向导窗口需要更新用户界面时会被调用来绘制内容。
        /// </summary>
        protected override bool DrawWizardGUI()
        {
            return false;
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
    }
}

#endif