using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DisabledFieldAttribute))]
public class DisabledFieldPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var disabledField = (DisabledFieldAttribute) attribute;
        
        EditorGUI.BeginDisabledGroup(disabledField.Disable);

        EditorGUI.PropertyField(position, property, label);
        
        EditorGUI.EndDisabledGroup();
    }
}
