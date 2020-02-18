namespace QuickEditor.Common
{
    using System;
    using System.IO;
    using UnityEditor;
    using UnityEngine;

    public enum PathMode
    {
        /// <summary>
        /// 系统全路径
        /// </summary>
        Full,

        /// <summary>
        /// Application.dataPath路径
        /// </summary>
        Data,

        /// <summary>
        /// Application.persistentDataPath路径
        /// </summary>
        Persistent,

        /// <summary>
        /// Application.temporaryCachePath路径
        /// </summary>
        Temporary,

        /// <summary>
        /// Application.streamingAssetsPath路径
        /// </summary>
        Streaming,

        /// <summary>
        /// 压缩的资源路径，Resources目录
        /// </summary>
        Resources,
    }

    public static class QuickPathUtils
    {
        public static readonly string AssetsRootDir = "Assets/";

        public static string AssetsDataPath = string.Empty;
        public static string PersistentDataPath = string.Empty;
        public static string StreamingAsstesPath = string.Empty;
        public static string TemporaryCachePath = string.Empty;
        public static string ProjectPath = string.Empty;
        public static string ResourcesPath = string.Empty;

        static QuickPathUtils()
        {
            AssetsDataPath = Application.dataPath;
            PersistentDataPath = Application.persistentDataPath;
            StreamingAsstesPath = Application.streamingAssetsPath;
            TemporaryCachePath = Application.temporaryCachePath;
            ProjectPath = string.Format("{0}/", Path.GetDirectoryName(AssetsDataPath));
            ResourcesPath = AssetsDataPath + "/Resources";
        }

        public static string SelectionAssetPath
        {
            get
            {
                string selectionpath = AssetsRootDir;
                int length = Selection.assetGUIDs.Length;
                if (length >= 1)
                {
                    selectionpath = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
                }
                return selectionpath;
            }
        }

        /// <summary>
        /// 返回ScriptableObject所在路径
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        public static string GetScriptableObjectPath(this ScriptableObject asset)
        {
            string path = AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(asset));
            return path.Substring(0, path.LastIndexOf("/"));
        }

        public static string GetProjectPath(this string srcName)
        {
            if (srcName.Equals(string.Empty))
            {
                return ProjectPath;
            }
            return Combine(ProjectPath, srcName);
        }

        public static string GetAssetPath(this string assetName)
        {
            if (assetName.Equals(string.Empty))
            {
                return AssetsRootDir;
            }
            return Combine(AssetsRootDir, assetName);
        }

        /// <summary>
        /// Convert global path to relative
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GlobalPathToRelative(this string path)
        {
            if (path.Equals(string.Empty)) { return AssetsRootDir; }
            if (path.StartsWith(Application.dataPath))
                return "Assets" + path.Substring(Application.dataPath.Length);
            else
                throw new ArgumentException("Incorrect path. Path doed not contain Application.datapath");
        }

        /// <summary>
        /// Convert relative path to global
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string RelativePathToGlobal(this string path)
        {
            return Combine(Application.dataPath, path);
        }

        /// <summary>
        /// Convert path from unix style to windows
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string MakeWindowsFormatPath(this string path)
        {
            return path.Replace("/", "\\");
        }

        /// <summary>
        /// Convert path from windows style to unix
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string MakeUnixFormatPath(this string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }
            var path1 = path.Replace("\\", "/");
            var path2 = path1.Replace("//", "/").Trim();
            path2 = path2.Replace("///", "/").Trim();
            path2 = path2.Replace("\\\\", "/").Trim();
            return path2;
        }

        private static string FormatPath(string path)
        {
            return path.Substring(path.IndexOf("Assets", StringComparison.Ordinal));
        }

        #region C# API 重写

        public static string Combine(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }

        public static string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        public static string GetExtension(string path)
        {
            return Path.GetExtension(path);
        }

        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        public static string GetFileNameWithoutExtension(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        public static string GetFullPath(string path)
        {
            return Path.GetFullPath(path);
        }

        #endregion C# API 重写
    }
}