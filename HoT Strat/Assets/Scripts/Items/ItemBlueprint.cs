using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory")]
public class ItemBlueprint : ScriptableObject
{
    new public string name = "New Item";
    public Sprite itemIcon = null;
    public bool isConsumable = false;
    public bool isEquipment = false;

    public virtual void Use()
    {

    }
}

