using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interact
{ 
    public ItemBlueprint item;


    public override void AnInteraction()
    {
        base.AnInteraction();

        PickUpThis();

    }

    void PickUpThis()
    {
        Debug.Log("Picked up " + item);
       bool wasPickedUp = CharacterInventory.instance.AddToInv(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }

    }

    public static void DiceAdd(ItemBlueprint item)
    {
        CharacterInventory.instance.AddToInv(item);
    }
}
