
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "NewRecruit", menuName = "Character/Playable", order = 1)]
public class RecruitClass : ScriptableObject
{
    public string myName;
    public string myClass;
    public int myRace;
    public int mySex;

    public int myClassNumeric;


    
}


