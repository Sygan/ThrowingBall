using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FolderCreatorWizard : ScriptableWizard
{
    public bool CreateFolder;
    public string FolderName;

    [MenuItem("Throwing Ball/Folder Creator")]
    public static void OpenWizard()
    {
        DisplayWizard<FolderCreatorWizard>("Folder Creator", "Create");
    }

    private void OnWizardCreate()
    {
        if(!CreateFolder)
            return;

        if (EditorUtility.DisplayDialog("Are you sure?", "Do you really wanna create this folder?", "Yes", "No"))
        {
            AssetDatabase.CreateFolder("Assets", FolderName);
        }
    }
}
