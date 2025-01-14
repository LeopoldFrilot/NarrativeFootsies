﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class NFGHelp
{
    public static NFGGameWizard GW => NFGGameWizard.Instance;
    public static List<T> AppendArray<T>(List<T> Arr1, List<T> Arr2)
    {
        foreach (var elem in Arr2)
        {
            Arr1.Add(elem);
        }

        return Arr1;
    }
}

// Create a custom ReadOnly attribute to use with the property drawer.
#if UNITY_EDITOR

public class ReadOnlyAttribute : PropertyAttribute { }

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
#endif