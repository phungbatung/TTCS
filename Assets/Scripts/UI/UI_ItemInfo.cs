using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemInfo : MonoBehaviour
{
    public ItemData item;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private TextMeshProUGUI itemDescription;
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetItemInfo(ItemData _item)
    {

        if (_item.itemtype == ItemType.Item)
            SetNormalItem(_item);
        else if (_item.itemtype == ItemType.Equipment)
            SetEquipmentItem(_item);
        gameObject.SetActive(true);
    }

    private void SetNormalItem(ItemData _item)
    {
        item = _item;
        itemImage.sprite = item.icon;
        itemName.text = item.name;
        itemType.text = itemType.ToString();
        itemDescription.text = item.itemDescription;
    }
    private void SetEquipmentItem(ItemData _item)
    {
        item = _item;
        EquipmentData equipment = _item as EquipmentData;
        itemImage.sprite = equipment.icon;
        itemName.text = equipment.name;
        itemType.text = equipment.itemtype.ToString() + "/" + equipment.equipmentType.ToString();
        itemDescription.text = equipment.Description();
    }
    
    public void CloseItemInfo()
    {
        itemImage.sprite = null;
        itemName.text = "";
        itemType.text = "";
        itemDescription.text = "";
        gameObject.SetActive(false);
    }

    public void EquipItem()
    {
        if(item.itemtype == ItemType.Equipment)
            Inventory.instance.Equip(item);
        CloseItemInfo();
    }

    public void RemoveItem()
    {
        Inventory.instance.RemoveItem(item);
        CloseItemInfo();
    }
}
