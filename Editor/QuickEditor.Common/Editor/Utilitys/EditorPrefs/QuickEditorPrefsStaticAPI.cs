namespace QuickEditor.Common
{
    using UnityEditor;
    using UnityEngine.Internal;

    public sealed class QuickEditorPrefsStaticAPI
    {
        public static bool HasKey(string key)
        {
            return EditorPrefs.HasKey(key);
        }

        public static void DeleteAll()
        {
            EditorPrefs.DeleteAll();
        }

        public static void DeleteKey(string key)
        {
            EditorPrefs.DeleteKey(key);
        }

        public static void SetInt(string key, int value)
        {
            EditorPrefs.SetInt(key, value);
        }

        public static int GetInt(string key)
        {
            return EditorPrefs.GetInt(key);
        }

        public static int GetInt(string key, [DefaultValue("0")] int defaultValue)
        {
            return EditorPrefs.GetInt(key, defaultValue);
        }

        public static void SetFloat(string key, float value)
        {
            EditorPrefs.SetFloat(key, value);
        }

        public static float GetFloat(string key)
        {
            return EditorPrefs.GetFloat(key);
        }

        public static float GetFloat(string key, [DefaultValue("0.0F")] float defaultValue)
        {
            return EditorPrefs.GetFloat(key, defaultValue);
        }

        public static void SetString(string key, string value)
        {
            EditorPrefs.SetString(key, value);
        }

        public static string GetString(string key)
        {
            return EditorPrefs.GetString(key);
        }

        public static string GetString(string key, [DefaultValue("\"\"")] string defaultValue)
        {
            return EditorPrefs.GetString(key, defaultValue);
        }

        public static void SetBool(string key, bool value)
        {
            if (value)
            {
                EditorPrefs.SetInt(key, 1);
            }
            else
            {
                EditorPrefs.SetInt(key, 0);
            }
        }

        public static bool GetBool(string key)
        {
            int val = EditorPrefs.GetInt(key);
            if (val == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}