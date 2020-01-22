using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public static CharacterInventory instance;

    public List<ItemBlueprint> items = new List<ItemBlueprint>();
    public int invMax = 8;


    public delegate void onItemChange();
    public onItemChange onItemChangeCallback;


    public bool AddToInv(ItemBlueprint item)
    {
        if (items.Count >= invMax)
        {
            return false;
        }
        else
        {
            items.Add(item);
            if (onItemChangeCallback != null)
            {
                onItemChangeCallback.Invoke();
            }
        }
        return true;
    }

    public void RemoveFromInv(ItemBlueprint item)
    {
        items.Remove(item);
        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
        }

 

        void Awake()
    {
        instance = this;

    }


}
