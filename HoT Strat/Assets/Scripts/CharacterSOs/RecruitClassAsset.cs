using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class RecruitClassAsset
{[MenuItem("Assets/Create/NewRecruit")]
    public static void CreateRecruit()
    {
        Utility_RecruitClass.CreateNewRecruit<RecruitClass>();
    }
}

