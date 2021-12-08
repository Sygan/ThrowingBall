using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BoxAggregatorWindow : EditorWindow
{
    private List<Box> boxes = new List<Box>();
    
    [MenuItem("Throwing Box/Box Aggregator")]
    public static void OpenWindow()
    {
        var window = GetWindow<BoxAggregatorWindow>("Box Aggregator");

        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("This window shows all Boxes in project.");

        if (GUILayout.Button("Find Boxes"))
        {
            boxes.Clear();
            
            var assets = AssetDatabase.FindAssets("t:Box");

            foreach (var asset in assets)
            {
                var boxAssetPath = AssetDatabase.GUIDToAssetPath(asset);
                var boxAsset = AssetDatabase.LoadAssetAtPath<Box>(boxAssetPath);
                
                boxes.Add(boxAsset);
                
                Debug.Log(boxAsset);
            }
        }

        EditorGUI.BeginDisabledGroup(true);
        
        for (var i = 0; i < boxes.Count; i++)
        {
            var box = boxes[i];
            
            EditorGUILayout.ObjectField("Element " + i, box, typeof(Box));
        }
        
        EditorGUI.EndDisabledGroup();
    }
}
