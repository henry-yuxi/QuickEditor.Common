#if UNITY_EDITOR

namespace QuickEditor.Common
{
    using UnityEditor;
    using UnityEngine;

    public class QuickScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        private static T mSetting;

        public static T Current
        {
            get
            {
                if (mSetting == null)
                {
                    mSetting = QuickAssetDatabase.LoadAssetFromUniqueAsset<T>(false);
                }
                return mSetting;
            }
        }

        public void Save()
        {
            if (mSetting == null) { return; }
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}

#endif