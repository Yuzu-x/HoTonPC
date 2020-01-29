using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : ScriptableObject
{
    public string paladinName;
    public int focusPoints = 0;
    public int maxHealthPoints = 390;

    public float meleeSkill = 3;
    public float rangeSkill = 3;

    public float basicDamage = 16;


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
            basicDamage = basicDamage + 10;
        }

        if (lightForgedRank == 2)
        {
            basicDamage = basicDamage + 20;
        }

        if (lightForgedRank == 3)
        {
            basicDamage = basicDamage + 34;
        }
    }

    void FortitudeBenevolenceStoicism()
    {
        if (fortitudeRank == 1 || benevolenceRank == 1 || stoicismRank == 1)
        {
            maxHealthPoints = 490;
            basicDamage = 30;

        }
        else if (fortitudeRank == 2 || benevolenceRank == 2 || stoicismRank == 2)
        {
            maxHealthPoints = 525;
            basicDamage = 47;

        }
        else if (fortitudeRank == 3 || benevolenceRank == 3 || stoicismRank == 3)
        {
            maxHealthPoints = 570;
            basicDamage = 58;

        }
        else if (fortitudeRank == 4 || benevolenceRank == 4 || stoicismRank == 4)
        {
            maxHealthPoints = 620;
            basicDamage = 69;

        }
        else if (fortitudeRank == 5 || benevolenceRank == 5 || stoicismRank == 5)
        {
            maxHealthPoints = 705;
            basicDamage = 80;

        }
        else if (fortitudeRank == 6 || benevolenceRank == 6 || stoicismRank == 6)
        {
            maxHealthPoints = 800;
            basicDamage = 95;

        }
    }
}

