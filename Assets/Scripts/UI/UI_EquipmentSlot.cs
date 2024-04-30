using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_EquipmentSlot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Sprite originSprite;
    [SerializeField] private Image itemImage;

    private ItemData item;

    public void UpdateItemSlot(ItemData _item)
    {

        item = _item;
        if (item != null)
        {
            itemImage.sprite = item.icon;
        }
        else
        {
            itemImage.sprite = originSprite;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item != null)
            Inventory.instance.Unequip(item);
    }
}
