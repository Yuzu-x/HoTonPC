using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : ClassBase
{
public Paladin()
    {
        CharacterClassName = "Paladin";
        CharacterClassDescription = "Through faith comes resilience and being tough to kill makes for a good Guardian. The holy power a Paladin channels can project a powerful aura that protects the Paladin from any harm and allows them to stand firm in the face of the strongest enemies. A Paladin can subjugate any foe and force them to repent their wicked ways.";
        MoveRange = 6;
        HealthPoints = 390;
        MeleeSkill = 3;
        RangedSkill = 3;
        TotalActionPoints = 3;
        BasicDamage = 16;
    }


    //Patience variable list
    public bool transferStress = false;
    public bool innerFocus = false;
    public float innerFocusRank = 0;
    public bool burnBright = false;
    public bool masterStrategist = false;
    public float masterStrategistRank = 0;
    public bool nirvana = false;
    public bool steadfast = false;
    public float steadfastRank = 0;
    public bool bringThemToJustice = false;
    public float bringThemToJusticeRank = 0;
    public bool fortitude = false;
    public float fortitudeRank = 0;
    public bool transcendence = false;
    public float transcendenceRank = 0;
    public bool lightSpeed = false;
    public float lightSpeedRank = 0;

    //Tolerance variable list
    public bool absolution = false;
    public bool shiningCompassion = false;
    public float shiningCompassionRank = 0;
    public bool rollPunch = false;
    public bool pacify = false;
    public float pacifyRank = 0;
    public bool seraphAcu = false;
    public bool quellingGrip = false;
    public float quellingGripRank = 0;
    public bool benevolence = false;
    public float benevolenceRank = 0;
    public bool divineIntervention = false;
    public float divineInterventionRank = 0;
    public bool ultimateRequisition = false;
    public float ultimateRequistionRank = 0;

    //Righteous variable list
    public bool burningShackles = false;
    public bool lightForged = false;
    public float lightForgedRank = 0;
    public bool radiantPrison = false;
    public bool searingPalm = false;
    public float searingPalmRank = 0;
    public bool zealousCharge = false;
    public bool divineOnslaught = false;
    public float divineOnslaughtRank = 0;
    public bool stoicism = false;
    public float stoicismRank = 0;
    public bool grandInterrogation = false;
    public float grandInterrogationRank = 0;
    public bool impossibleSword = false;
    public float impossibleSwordRank = 0;


    void Start()
    {
        if (fortitude || benevolence || stoicism)
        {
            FortitudeBenevolenceStoicism();
        }

    }


    void Update()
    {
        if (rollPunch)
        {
            RollingWithThePunches();

        }

        if (seraphAcu)
        {
            SeraphicAcuity();
        }


    }

    void ExceptionalForgiveness()
    {

    }

    void RollingWithThePunches()
    {

    }

    void SeraphicAcuity()
    {

    }

    void LightForged()
    {
        if (lightForgedRank == 1)
        {
            BasicDamage = BasicDamage + 10;
        }

        if (lightForgedRank == 2)
        {
            BasicDamage = BasicDamage + 20;
        }

        if (lightForgedRank == 3)
        {
            BasicDamage = BasicDamage + 34;
        }
    }

    void FortitudeBenevolenceStoicism()
    {
        if (fortitudeRank == 1 || benevolenceRank == 1 || stoicismRank == 1)
        {
            HealthPoints = 490;
            BasicDamage = 30;

        }
        else if (fortitudeRank == 2 || benevolenceRank == 2 || stoicismRank == 2)
        {
            HealthPoints = 525;
            BasicDamage = 47;

        }
        else if (fortitudeRank == 3 || benevolenceRank == 3 || stoicismRank == 3)
        {
            HealthPoints = 570;
            BasicDamage = 58;

        }
        else if (fortitudeRank == 4 || benevolenceRank == 4 || stoicismRank == 4)
        {
            HealthPoints = 620;
            BasicDamage = 69;

        }
        else if (fortitudeRank == 5 || benevolenceRank == 5 || stoicismRank == 5)
        {
            HealthPoints = 705;
            BasicDamage = 80;

        }
        else if (fortitudeRank == 6 || benevolenceRank == 6 || stoicismRank == 6)
        {
            HealthPoints = 800;
            BasicDamage = 95;

        }
    }
}

