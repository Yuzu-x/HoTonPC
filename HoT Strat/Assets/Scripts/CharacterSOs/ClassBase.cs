using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBase
{ 
    private string characterClassName;
    private string characterClassDescription;

    //Basic Character Attributes
    private int moveRange;
    private int healthPoints;
    private int meleeSkill;
    private int rangedSkill;
    private int totalActionPoints;
    private int basicDamage;

    public string CharacterClassName
    {
        get { return characterClassName; }
        set { characterClassName = value; }

    }

    public string CharacterClassDescription
    {
        get { return characterClassDescription; }
        set { characterClassDescription = value; }
    }

    public int MoveRange
    {
        get { return moveRange; }
        set { moveRange = value; }
    }

    public int HealthPoints
    {
        get { return healthPoints; }
        set { healthPoints = value; }
    }

    public int MeleeSkill
    {
        get { return meleeSkill; }
        set { meleeSkill = value; }
    }

    public int RangedSkill
    {
        get { return rangedSkill; }
        set { rangedSkill = value; }
    }

    public int TotalActionPoints
    {
        get { return totalActionPoints; }
        set { totalActionPoints = value; }
    }

    public int BasicDamage
    {
        get { return basicDamage; }
        set { basicDamage = value; }
    }
}
