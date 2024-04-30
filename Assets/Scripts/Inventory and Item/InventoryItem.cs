using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public ItemData itemData;
    public int stackSize;
    public InventoryItem(ItemData _item)
    {
        this.itemData = _item;
        AddStack();
    }

    public InventoryItem()
    {
       itemData = null;
        stackSize = 0;
    }

    public void AddStack() => stackSize++;
    public void RemoveStack() => stackSize--;
}
