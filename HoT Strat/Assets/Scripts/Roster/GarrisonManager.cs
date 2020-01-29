using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarrisonManager : MonoBehaviour
{
    public int garrisonCapacity = 10;
    public int currentGarrison = 0;

    public int role = 0;
    public int roleCapacity = 4;

    public int recruitClass = 0;
    public int recruitRace = 0;
    public bool recruitMale;
    public string recruitName;
    public string recruitClassEnglish;
    public int recruitID = 0;

    public int garrisonSlot = 0;

    public AvailableRecruits garrisonSlotHolder;


}