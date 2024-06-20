using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ItemSlotInventory : UI_ItemSlot, IPointerClickHandler
{
    [SerializeField]protected TextMeshProUGUI amount;
    [SerializeField] private UI_ItemInfo itemInfo;

    public override void UpdateItemSlot(InventoryItem _item)
    {

        if(_item != null)
        {
        item= _item;
            itemImage.sprite = item.itemData.icon;
            if (item.stackSize > 1)
                amount.text = item.stackSize.ToString();
            else
                amount.text = "";
        }
        else
        {
            item= null;
            itemImage.sprite=originSprite;
            amount.text = "";
        }
    }

   
    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
            itemInfo.SetItemInfo(item.itemData);
    }
}
