namespace QuickEditor.Common
{
    using System.IO;
    using System.Reflection;

    using Type = System.Type;

    public static class QuickLayoutStaticAPI
    {
        private static MethodInfo _miLoadWindowLayout;
        private static MethodInfo _miSaveWindowLayout;
        private static MethodInfo _miReloadWindowLayoutMenu;

        private static bool _available;

        static QuickLayoutStaticAPI()
        {
            Type tyWindowLayout = Type.GetType("UnityEditor.WindowLayout,UnityEditor");
            Type tyEditorUtility = Type.GetType("UnityEditor.EditorUtility,UnityEditor");
            Type tyInternalEditorUtility = Type.GetType("UnityEditorInternal.InternalEditorUtility,UnityEditor");

            if (tyWindowLayout != null && tyEditorUtility != null && tyInternalEditorUtility != null)
            {
                _miLoadWindowLayout = tyWindowLayout.GetMethod("LoadWindowLayout", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(string), typeof(bool) }, null);
                _miSaveWindowLayout = tyWindowLayout.GetMethod("SaveWindowLayout", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(string) }, null);
                _miReloadWindowLayoutMenu = tyInternalEditorUtility.GetMethod("ReloadWindowLayoutMenu", BindingFlags.Public | BindingFlags.Static);

                if (_miLoadWindowLayout == null || _miSaveWindowLayout == null || _miReloadWindowLayoutMenu == null)
                    return;

                _available = true;
            }
        }

        public static bool IsAvailable
        {
            get { return _available; }
        }

        public static void SaveLayoutToAsset(string assetPath)
        {
            SaveLayout(Path.Combine(Directory.GetCurrentDirectory(), assetPath));
        }

        public static void LoadLayoutFromAsset(string assetPath)
        {
            if (_miLoadWindowLayout != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), assetPath);
                _miLoadWindowLayout.Invoke(null, new object[] { path, false });
            }
        }

        public static void SaveLayout(string path)
        {
            if (_miSaveWindowLayout != null)
                _miSaveWindowLayout.Invoke(null, new object[] { path });
        }
    }
}