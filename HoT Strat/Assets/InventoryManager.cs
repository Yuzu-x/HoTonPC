using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Transform invParent;

    CharacterInventory myItems;

    ItemSlotManager[] slots;

    void Start()
    {
        myItems = CharacterInventory.instance;
        myItems.onItemChangeCallback += UpdateInventory;

        slots = invParent.GetComponentsInChildren<ItemSlotManager>();

    }

    void Update()
    {
        
    }

    void UpdateInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < myItems.items.Count)
            {
                slots[i].AddItem(myItems.items[i]);

            }
            else
            {
                slots[i].EmptySlot();

            }
        }
    }
}
