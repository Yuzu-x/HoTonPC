using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class Utility_RecruitClass
{
   public static void CreateNewRecruit<NR>() where NR : ScriptableObject
    {
        NR asset = RecruitClass.CreateInstance<NR>();

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if(path == "")
        {
            path = "Assets";

        }
        else if(Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");

        }
        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(NR).ToString() + ".asset");

        AssetDatabase.CreateAsset(asset, assetPathAndName);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
    
}
