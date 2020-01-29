using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotManager : MonoBehaviour
{
    ItemBlueprint item;
    public Image itemIcon;

    public void AddItem(ItemBlueprint newItem)
    {
        item = newItem;

        itemIcon.sprite = item.itemIcon;
        itemIcon.enabled = true;

    }

    public void EmptySlot()
    {
        item = null;
        itemIcon.sprite = null;
        itemIcon.enabled = false;

    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();

        }
    }
}
