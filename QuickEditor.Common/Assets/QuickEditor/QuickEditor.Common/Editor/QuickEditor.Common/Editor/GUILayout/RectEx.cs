using QuickEditor.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(RectTransform))]
public class RectEx : DecoratorEditor
{
    public RectEx() : base("RectTransformEditor") { }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Adding this button"))
        {
            Debug.Log("Adding this button");
        }
    }
}