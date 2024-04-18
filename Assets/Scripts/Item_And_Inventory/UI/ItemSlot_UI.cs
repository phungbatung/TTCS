using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot_UI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]private Sprite originSprite;
    [SerializeField]private Image itemImage;
    [SerializeField]private TextMeshProUGUI amount;

    private InventoryItem item;

    public void UpdateItemSlot(InventoryItem _item)
    {

        item= _item;
        if(item.itemData != null)
        {
            /*Debug.Log(gameObject.name + " not null");
            if (item.itemData.icon == null)
                Debug.Log("icon Null");*/
            itemImage.sprite = item.itemData.icon;
            if (item.stackSize > 1)
                amount.text = item.stackSize.ToString();
            else
                amount.text = "";
        }
        else
        {
            Debug.Log("Debug");
            itemImage.sprite=originSprite;
            amount.text = "";
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item.itemData!=null && item.itemData.itemtype == ItemType.Equipment)
            Inventory.instance.Equip(item);
    }
}
