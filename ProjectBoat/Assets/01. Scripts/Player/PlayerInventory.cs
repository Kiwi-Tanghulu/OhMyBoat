using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private InputSO input;

    [SerializeField] private int maxItemCount;

    private int currentItemIndex;
    private IGrabbable[] inventory;

    public Action<int> OnChangeCurrentItemIndex;

    private void Awake()
    {
        inventory = new IGrabbable[maxItemCount];

        input.OnMouseWheelEvent += Input_OnMouseWheelEvent;
    }

    private void OnDestroy()
    {
        input.OnMouseWheelEvent -= Input_OnMouseWheelEvent;
    }

    private void Input_OnMouseWheelEvent(float value)
    {
        if(value > 0)
        {
            currentItemIndex = (currentItemIndex + 1) % maxItemCount;
        }
        else if(value < 0)
        {
            if(currentItemIndex == 0)
                currentItemIndex = maxItemCount - 1;
            else
                currentItemIndex = (currentItemIndex - 1) % maxItemCount;
        }
        
        OnChangeCurrentItemIndex?.Invoke(currentItemIndex);
    }

    public void AddItem(IGrabbable item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                return;
            }
        }
    }

    public void RemoveItem(IGrabbable item)
    {
        int index = Array.IndexOf(inventory, item);

        inventory[index] = null;
    }

    public void RemoveItem(int index)
    {
        inventory[index] = null;
    }

    public IGrabbable GetItem(int index)
    {
        currentItemIndex = index;

        return inventory[index];
    }

    public IGrabbable GetCurrentItem()
    {
        return inventory[currentItemIndex];
    }
}
