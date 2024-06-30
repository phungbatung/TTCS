using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UI_ItemInfo : MonoBehaviour
{
    public ItemData item;
    [SerializeField] protected Image itemImage;
    [SerializeField] protected TextMeshProUGUI itemName;
    [SerializeField] protected TextMeshProUGUI itemType;
    [SerializeField] protected TextMeshProUGUI itemDescription;
    
    protected virtual void Awake()
    {
        gameObject.SetActive(false);
    }

    public virtual void SetItemInfo(ItemData _item)
    {
        gameObject.SetActive(true);
        if (_item.itemType == ItemType.Item)
            SetNormalItem(_item);
        else if (_item.itemType == ItemType.Equipment)
            SetEquipmentItem(_item);
        else if (_item.itemType == ItemType.Potion)
            SetPotionItem(_item);
    }

    protected virtual void SetNormalItem(ItemData _item)
    {
        item = _item;
        itemImage.sprite = item.icon;
        itemName.text = item.name;
        itemType.text = item.ItemType();
        itemDescription.text = item.itemDescription;
    }
    protected virtual void SetEquipmentItem(ItemData _item)
    {
        item = _item;
        ItemData_Equipment equipment = _item as ItemData_Equipment;
        itemImage.sprite = equipment.icon;
        itemName.text = equipment.name;
        itemType.text = equipment.ItemType();
        itemDescription.text = equipment.Description();
    }
    protected virtual void SetPotionItem(ItemData _item)
    {
        item = _item;
        ItemData_Potion potion = _item as ItemData_Potion;
        itemImage.sprite = potion.icon;
        itemName.text = potion.name;
        itemType.text = potion.ItemType();
        itemDescription.text = potion.Description();
    }
    
    public virtual void CloseItemInfo()
    {
        itemImage.sprite = null;
        itemName.text = "";
        itemType.text = "";
        itemDescription.text = "";
        gameObject.SetActive(false);
    }

    public virtual void EquipItem()
    {
        if(item.itemType == ItemType.Equipment)
            Inventory.instance.Equip(item);
        CloseItemInfo();
    }

    public virtual void RemoveItem()
    {
        Inventory.instance.RemoveItem(item);
        CloseItemInfo();
    }

    public virtual void UsePotion()
    {
        Inventory.instance.UsePotion(item);
    }

    public virtual void MoveToSlot()
    {
        Inventory.instance.SetPotion(item);
    }
   
}
