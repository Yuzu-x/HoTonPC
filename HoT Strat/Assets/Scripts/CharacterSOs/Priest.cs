using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : ClassBase
{
    public Priest()
    {
        CharacterClassName = "Priest";
        CharacterClassDescription = "";
        MoveRange = 6;
        HealthPoints = 195;
        MeleeSkill = 5;
        RangedSkill = 2;
        TotalActionPoints = 3;
        BasicDamage = 9;
    }
}
