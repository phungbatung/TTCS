using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.EventSystems;
using TMPro;

public class UI_ItemSlotPotion : UI_ItemSlot, IPointerClickHandler
{
    [SerializeField] protected TextMeshProUGUI amount;


    public override void UpdateItemSlot(InventoryItem _item)
    {

        if (_item != null)
        {
            item = _item;
            itemImage.sprite = item.itemData.icon;
            itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, 255);
            if (item.stackSize > 1)
                amount.text = item.stackSize.ToString();
            else
                amount.text = "";
        }
        else
        {
            item = null;
            itemImage.sprite = originSprite;
            itemImage.color = new Color(itemImage.color.r, itemImage.color.g, itemImage.color.b, 0);
            amount.text = "";
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory.instance.UseCurrentPotion();
    }
}
