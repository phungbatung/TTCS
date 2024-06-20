using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ItemSlotShop : UI_ItemSlot, IPointerClickHandler
{
    public UI_ItemInfo itemInfo;
    public TextMeshProUGUI priceUI;
    private int price;
    public override void UpdateItemSlot(InventoryItem _item)
    {
        if (_item!=null)
        {
            item = _item;
            itemImage.sprite = _item.itemData.icon;
            price = _item.itemData.price + UnityEngine.Random.Range(-_item.itemData.price / 5, _item.itemData.price / 5); // +-20% cost
        }
        else
        {
            item = null;
            itemImage.sprite = originSprite;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        itemInfo.SetItemInfo(item.itemData);
        priceUI.text = "Price: " + price.ToString();
    }
}
