using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot_UI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]private Sprite originSprite;
    [SerializeField]private Image itemImage;
    [SerializeField]private TextMeshProUGUI amount;

    private InventoryItem item;

    public void UpdateItemSlot(InventoryItem _item)
    {

        if(_item != null)
        {
        item= _item;
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
            item= null;
            itemImage.sprite=originSprite;
            amount.text = "";
        }
    }

   
    public void OnPointerClick(PointerEventData eventData)
    {
        if (item != null)
            UI_ItemInfo.instance.SetItemInfo(item.itemData);
    }
}
