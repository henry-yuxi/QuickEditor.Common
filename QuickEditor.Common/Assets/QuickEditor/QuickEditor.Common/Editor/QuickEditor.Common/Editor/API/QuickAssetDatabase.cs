﻿namespace QuickEditor.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using UnityEditor;
    using UnityEngine;

    public class QuickAssetDatabase
    {
        public enum AssetPathMode
        {
            SelectionAssetPath,
            ScriptableObjectAssetPath,
        }

        public static bool ContainsAsset<T>() where T : ScriptableObject
        {
            string[] guids = FindAssets<T>();
            return guids != null && guids.Length > 0;
        }

        public static T CreateAssetProjectWindow<T>(string filename) where T : ScriptableObject
        {
            var asset = ScriptableObject.CreateInstance<T>();
            ProjectWindowUtil.CreateAsset(asset, filename + ".asset");
            return asset;
        }

        public static T CreateAsset<T>(AssetPathMode type = AssetPathMode.ScriptableObjectAssetPath) where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();
            return CreateAsset(asset, (type == AssetPathMode.ScriptableObjectAssetPath ? asset.GetScriptableObjectPath() : QuickPathUtils.SelectionAssetPath)) as T;
        }

        public static T CreateAsset<T>(string targetPath) where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();

            return CreateAsset(asset, targetPath) as T;
        }

        public static UnityEngine.Object CreateAsset(ScriptableObject asset, AssetPathMode type = AssetPathMode.ScriptableObjectAssetPath)
        {
            return CreateAsset(asset, (type == AssetPathMode.ScriptableObjectAssetPath ? asset.GetScriptableObjectPath() : QuickPathUtils.SelectionAssetPath));
        }

        public static UnityEngine.Object CreateAsset(UnityEngine.Object asset, string targetPath)
        {
            string fileName = AssetDatabase.GenerateUniqueAssetPath(targetPath + "/" + asset.GetType().Name + ".asset");
            CreateAndSaveAsset(asset, fileName);
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
            return asset;
        }

        public static void CreateAndSaveAsset(UnityEngine.Object asset, string path)
        {
            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public static bool DeleteAsset(string path)
        {
            var file = new FileInfo(path);
            if (!file.Exists) { return false; }
            file.Delete();
            return true;
        }

        public static T LoadAsset<T>(string targetPath, bool needCreateIfExist = true) where T : ScriptableObject
        {
            T asset = default(T);
            if (string.IsNullOrEmpty(targetPath)) { return asset; }
            asset = (T)AssetDatabase.LoadAssetAtPath(FindAssetPath<T>(), typeof(T));
            if (asset == null && needCreateIfExist)
            {
                asset = CreateAsset<T>(targetPath);
            }
            return asset;
        }

        public static T LoadAssetFromGUID<T>(string guid) where T : ScriptableObject
        {
            T asset = default(T);
            if (string.IsNullOrEmpty(guid)) { return asset; }
            return AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(guid), typeof(UnityEngine.Object)) as T;
        }

        public static T LoadAssetFromUniqueAsset<T>(string path) where T : ScriptableObject
        {
            return LoadAssetFromUniqueAsset<T>(path, typeof(T).Name);
        }

        public static T LoadAssetFromUniqueAsset<T>(string targetPath, string fileName) where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();
            var uniquePath = AssetDatabase.GenerateUniqueAssetPath(targetPath + "/" + fileName + ".asset");
            CreateAndSaveAsset(asset, uniquePath);
            var final = AssetDatabase.LoadAssetAtPath(uniquePath, typeof(T)) as T;
            return final;
        }

        public static T LoadAssetFromUniqueAsset<T>(bool mFocusProjectWindow = true) where T : ScriptableObject
        {
            T asset = default(T);
            asset = (T)AssetDatabase.LoadAssetAtPath(FindAssetPath<T>(), typeof(T));
            if (asset == null)
            {
                asset = ScriptableObject.CreateInstance<T>();
                string fileName = AssetDatabase.GenerateUniqueAssetPath(asset.GetScriptableObjectPath() + "/Resources/" + asset.GetType().Name + ".asset");
                CreateAndSaveAsset(asset, fileName);
            }
            if (mFocusProjectWindow)
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = asset;
            }
            return asset;
        }

        #region FindAssets

        public static string[] FindAssets<T>(string[] searchInFolders = null) where T : UnityEngine.Object
        {
            return FindAssets(string.Format("t:{0}", typeof(T).FullName), searchInFolders);
        }

        public static string[] FindAssets(string filter, string[] searchInFolders = null)
        {
            return (searchInFolders == null || searchInFolders.Length < 1) ? AssetDatabase.FindAssets(filter) : AssetDatabase.FindAssets(filter, searchInFolders);
        }

        public static string FindAssetPath<T>() where T : UnityEngine.Object
        {
            string[] guids = FindAssets<T>();

            if (guids != null && guids.Length > 0)
            {
                if (guids.Length > 1)
                {
                    Debug.LogWarning("More than one instance of " + typeof(T).FullName + " exists! Using the first occurance.");
                }
                return AssetDatabase.GUIDToAssetPath(guids[0]);
            }
            Debug.LogError(string.Format("Asset [{0}.asset] not found", typeof(T).FullName));
            return string.Empty;
        }

        #endregion FindAssets

        /// <summary>
        /// Searches the whole project and attempts to load the first asset matching name (excluding extension).
        /// </summary>
        /// <param name="name">Name of the file without extension</param>
        public static T LoadAssetWithName<T>(string name) where T : UnityEngine.Object
        {
            T asset = null;

            try
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets(name)[0]);
                asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            }
            catch (Exception ex)
            {
                Debug.LogError("Could not load asset with name " + name + " | Error: " + ex.Message);
            }

            return asset;
        }

        /// <summary>
        /// Searches the whole projects for assets of type T and returns them as a list
        /// </summary>
        /// <typeparam name="T">Type to look for, derived from UnityEngine.Object</typeparam>
        /// <returns>List of assets of type T found</returns>
        public static List<T> LoadAssetsOfType<T>() where T : UnityEngine.Object
        {
            List<T> assets = new List<T>();
            string[] guids = AssetDatabase.FindAssets(string.Format("t:{0}", typeof(T).ToString().Replace("UnityEngine.", string.Empty)));

            for (int i = 0; i < guids.Length; i++)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
                T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                if (asset != null)
                {
                    assets.Add(asset);
                }
            }
            return assets;
        }
    }
}