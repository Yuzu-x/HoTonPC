using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class RecruitGeneration : MonoBehaviour
    {

    //visible information
    public RecruitClass newRecruit;


    public void GenerateRecruit()
    {
        newRecruit.myClassNumeric = Random.Range(1, 13);

        //Kshila cannot be Knights, Fighters or Tamers
        if(newRecruit.myClassNumeric == 2 || newRecruit.myClassNumeric == 8 || newRecruit.myClassNumeric == 12)
        {
            newRecruit.myRace = Random.Range(1, 6);

            if(newRecruit.myRace == 4)
            {
                newRecruit.myRace = 1;
            }
        }

        //Curassa cannot be Engineers, Mages or Necromancers
        else if(newRecruit.myClassNumeric == 3 || newRecruit.myClassNumeric == 9 || newRecruit.myClassNumeric == 10)
        {
            newRecruit.myRace = Random.Range(1, 6);

            if(newRecruit.myRace == 5)
            {
                newRecruit.myRace = 3;
            }
        }
        //Assassins can be Mantoeda
        else if(newRecruit.myClassNumeric == 7)
        {
            newRecruit.myRace = Random.Range(1, 7);

        }
        //Witches can be Hawz
        else if(newRecruit.myClassNumeric == 5)
        {
            newRecruit.myRace = Random.Range(1, 8);

            if(newRecruit.myRace == 6)
            {
                newRecruit.myRace = 7;
            }
        }
        else
        {
            newRecruit.myRace = Random.Range(1, 6);
        }

        newRecruit.mySex = Random.Range(1, 3);

        //If Mantoeda, make it Chi'Klak
        if(newRecruit.myClassNumeric == 7 && newRecruit.myRace == 6)
        {
            newRecruit.mySex = 2;
            newRecruit.myName = "Chi'Klak the Rogue";
        }

        if (newRecruit.myClassNumeric == 5 && newRecruit.myRace == 7)
        {
            newRecruit.mySex = 1;
            newRecruit.myName = "Hu Lenoo, Voice of the Great Plain";
        }

        if(newRecruit.myClassNumeric == 1)
        {
            newRecruit.myClass = "Paladin";
        }
        else if(newRecruit.myClassNumeric == 2)
        {
            newRecruit.myClass = "Knight";
        }
        else if(newRecruit.myClassNumeric == 3)
        {
            newRecruit.myClass = "Engineer";
        }
        else if(newRecruit.myClassNumeric == 4)
        {
            newRecruit.myClass = "Priest";
        }
        else if(newRecruit.myClassNumeric == 5)
        {
            newRecruit.myClass = "Witch";
        }
        else if(newRecruit.myClassNumeric == 6)
        {
            newRecruit.myClass = "Miasmatic";
        }
        else if(newRecruit.myClassNumeric == 7)
        {
            newRecruit.myClass = "Assassin";
        }
        else if(newRecruit.myClassNumeric == 8)
        {
            newRecruit.myClass = "Fighter";
        }
        else if(newRecruit.myClassNumeric == 9)
        {
            newRecruit.myClass = "Mage";
        }
        else if(newRecruit.myClassNumeric == 10)
        {
            newRecruit.myClass = "Necromancer";
        }
        else if(newRecruit.myClassNumeric == 11)
        {
            newRecruit.myClass = "Ranger";
        }
        else if(newRecruit.myClassNumeric == 12)
        {
            newRecruit.myClass = "Tamer";
        }
              }

}

