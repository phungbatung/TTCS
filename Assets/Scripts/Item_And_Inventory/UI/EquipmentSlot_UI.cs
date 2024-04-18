using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot_UI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Sprite originSprite;
    [SerializeField] private Image itemImage;

    private InventoryItem item;

    public void UpdateItemSlot(InventoryItem _item)
    {

        item = _item;
        if (item.itemData != null)
        {
            itemImage.sprite = item.itemData.icon;
        }
        else
        {
            itemImage.sprite = originSprite;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item.itemData != null)
            Inventory.instance.Unequip(item);
    }
}
