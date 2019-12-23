namespace QuickEditor.Common
{
    using System.Collections;
    using UnityEditor;

    public static class QuickEditorCoroutineExtensions
    {
        public static QuickEditorCoroutines.QEditorCoroutine StartCoroutine(this EditorWindow thisRef, IEnumerator coroutine)
        {
            return QuickEditorCoroutines.StartCoroutine(coroutine, thisRef);
        }

        public static QuickEditorCoroutines.QEditorCoroutine StartCoroutine(this EditorWindow thisRef, string methodName)
        {
            return QuickEditorCoroutines.StartCoroutine(methodName, thisRef);
        }

        public static QuickEditorCoroutines.QEditorCoroutine StartCoroutine(this EditorWindow thisRef, string methodName, object value)
        {
            return QuickEditorCoroutines.StartCoroutine(methodName, value, thisRef);
        }

        public static void StopCoroutine(this EditorWindow thisRef, IEnumerator coroutine)
        {
            QuickEditorCoroutines.StopCoroutine(coroutine, thisRef);
        }

        public static void StopCoroutine(this EditorWindow thisRef, string methodName)
        {
            QuickEditorCoroutines.StopCoroutine(methodName, thisRef);
        }

        public static void StopAllCoroutines(this EditorWindow thisRef)
        {
            QuickEditorCoroutines.StopAllCoroutines(thisRef);
        }
    }
}