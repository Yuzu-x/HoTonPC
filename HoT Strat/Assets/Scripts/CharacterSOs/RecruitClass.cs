
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "NewRecruit", menuName = "Character/Playable", order = 1)]
public class RecruitClass : ScriptableObject
{
    public string myName;
    public string myClass;
    public Sprite myClassSymbol;

    public int myClassNumeric;
    public int myRaceNumeric;
    public int mySexNumeric;

    public void Start()
    {
        myClassNumeric = Random.Range(1, 13);
        mySexNumeric = Random.Range(1, 3);

        if (myClassNumeric == 5 || myClassNumeric == 7)
        {
            if(myClassNumeric == 5)
            {
                myRaceNumeric = Random.Range(1, 7);
            }
            else if(myClassNumeric == 7)
            {
                myRaceNumeric = Random.Range(1, 8);
                if(myRaceNumeric == 6)
                {
                    myRaceNumeric = 7;
                }
            }
        }
        else
        {
            myRaceNumeric = Random.Range(1, 6);
        }

        if(myClassNumeric == 1)
        {
            myClass = "Paladin";
        }
        else if(myClassNumeric == 2)
        {
            myClass = "Knight";
        }
        else if (myClassNumeric == 3)
        {
            myClass = "Engineer";
        }
        else if (myClassNumeric == 4)
        {
            myClass = "Priest";
        }
        else if (myClassNumeric == 5)
        {
            myClass = "Witch";
        }
        else if (myClassNumeric == 6)
        {
            myClass = "Miasmatic";
        }
        else if (myClassNumeric == 7)
        {
            myClass = "Assassin";
        }
        else if (myClassNumeric == 8)
        {
            myClass = "Fighter";
        }
        else if (myClassNumeric == 9)
        {
            myClass = "Mage";
        }
        else if (myClassNumeric == 10)
        {
            myClass = "Necromancer";
        }
        else if (myClassNumeric == 11)
        {
            myClass = "Ranger";
        }
        else if (myClassNumeric == 12)
        {
            myClass = "Tamer";
        }

    }


}


