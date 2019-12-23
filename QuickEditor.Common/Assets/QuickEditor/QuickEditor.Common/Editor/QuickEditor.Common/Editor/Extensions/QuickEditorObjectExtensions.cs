namespace QuickEditor.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    public static class QuickEditorObjectExtensions
    {
        public static object display(this object src, string description, int offset = 0)
        {
            EditorGUILayout.BeginVertical(new GUIStyle() { margin = new RectOffset(offset == 0 ? 0 : 16, 0, 0, 0) });
            if (src is Array)
            {
                EditorGUILayout.LabelField(description + "  (Array)");

                var array = src as Array;
                var showVert = array.Length > 0;
                if (showVert)
                {
                    EditorGUILayout.BeginVertical();
                }

                int removeID = -1;
                for (int i = 0; i < array.Length; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(description + " Item" + i);
                    if (GUILayout.Button("-"))
                    {
                        removeID = i;
                        break;
                    }
                    EditorGUILayout.EndHorizontal();

                    var v = array.GetValue(i);
                    ((Array)src).SetValue(v.display(v.GetType().Name, offset + 1), i);
                }

                if (removeID != -1)
                {
                    var elementType = array.GetType().GetElementType();
                    var lstType = typeof(List<>).MakeGenericType(new Type[] { elementType });
                    var lst = (IList)Activator.CreateInstance(lstType, null);
                    for (int i = 0, count = array.Length; i < count; i++)
                    {
                        lst.Add(array.GetValue(i));
                    }
                    lst.RemoveAt(removeID);

                    src = (Array)lstType.GetMethod("ToArray").Invoke(lst, null);

                    lstType = null;
                    lst.Clear();
                }

                if (GUILayout.Button("+    " + description))
                {
                    var elementType = array.GetType().GetElementType();
                    var lstType = typeof(List<>).MakeGenericType(new Type[] { elementType });
                    var lst = (IList)Activator.CreateInstance(lstType, null);
                    for (int i = 0, count = array.Length; i < count; i++)
                    {
                        lst.Add(array.GetValue(i));
                    }
                    lst.Add(elementType == typeof(string)
                        ? string.Empty
                        : elementType.Assembly.CreateInstance(elementType.FullName));

                    src = lstType.GetMethod("ToArray").Invoke(lst, null);

                    lstType = null;
                    lst.Clear();
                }

                if (showVert)
                {
                    EditorGUILayout.EndVertical();
                }

                EditorGUILayout.EndVertical();
                return src;
            }
            else if (src is IList) // 注意：数组类型也属于IList
            {
                EditorGUILayout.LabelField(description + "  (List)");

                var lst = src as IList;
                var showVert = lst.Count > 0;
                if (showVert)
                {
                    EditorGUILayout.BeginVertical();
                }

                int removeID = -1;
                for (int i = 0; i < lst.Count; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(description + " Item" + i);
                    if (GUILayout.Button("-"))
                    {
                        removeID = i;
                        break;
                    }
                    EditorGUILayout.EndHorizontal();

                    lst[i] = lst[i].display(lst[i].GetType().Name, offset + 1);
                }

                if (removeID != -1)
                {
                    lst.RemoveAt(removeID);
                }

                if (GUILayout.Button("+    " + description))
                {
                    var type = lst.GetType().GetGenericArguments()[0];
                    lst.Add(type == typeof(string)
                        ? string.Empty
                        : type.Assembly.CreateInstance(type.FullName));
                }

                if (showVert)
                {
                    EditorGUILayout.EndVertical();
                }

                EditorGUILayout.EndVertical();
                return src;
            }
            else if (src is int || src is long || src is string || src is byte || src is Enum || src is bool)
            {
            }
            else // if (src is ProtoBuf.IExtensible)
            {
                EditorGUILayout.LabelField(description + "  (Class)");

                var pros = src.GetType().GetProperties();
                EditorGUILayout.BeginVertical();
                foreach (var tmp in pros)
                {
                    var obj = tmp.GetValue(src, null);
                    if (obj == null)
                    {
                        if (tmp.PropertyType == typeof(string))
                        {
                            obj = string.Empty;
                        }
                        else if (tmp.PropertyType.IsSubclassOf(typeof(Array)))
                        {
                            obj = Activator.CreateInstance(tmp.PropertyType, 0);
                        }
                        else
                        {
                            obj = tmp.PropertyType.Assembly.CreateInstance(tmp.PropertyType.FullName);
                        }
                    }

                    obj = obj.display(tmp.Name, offset + 1);

                    if (obj is IList && !(obj is Array)) continue;
                    tmp.SetValue(src, obj, null);
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.EndVertical();
                return src;
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(description);

            if (src is int)
            {
                src = EditorGUILayout.IntField((int)src);
            }
            else if (src is long)
            {
                src = long.Parse(EditorGUILayout.TextField(src.ToString()));
            }
            else if (src is string)
            {
                src = EditorGUILayout.TextField(src.ToString());
                if (src == null)
                    src = "";
            }
            else if (src is byte)
            {
                src = (byte)EditorGUILayout.IntField((byte)src);
            }
            else if (src is Enum)
            {
                src = EditorGUILayout.EnumPopup(src as Enum);
            }
            else if (src is bool)
            {
                src = EditorGUILayout.Toggle((bool)src);
            }
            EditorGUILayout.Space();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();
            return src;
        }
    }
}
