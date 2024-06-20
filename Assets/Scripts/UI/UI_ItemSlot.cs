using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UI_ItemSlot : MonoBehaviour
{
    [SerializeField] protected Sprite originSprite;
    [SerializeField] protected Image itemImage;

    protected InventoryItem item;

    public abstract void UpdateItemSlot(InventoryItem _item);
}
