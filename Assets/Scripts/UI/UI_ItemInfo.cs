using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UI_ItemInfo : MonoBehaviour
{
    public ItemData item;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private TextMeshProUGUI itemDescription;
    private BaseButton[] buttons;
    private void Awake()
    {
        buttons = GetComponentsInChildren<BaseButton>();
        gameObject.SetActive(false);
    }

    public void SetItemInfo(ItemData _item)
    {
        if (_item.itemType == ItemType.Item)
            SetNormalItem(_item);
        else if (_item.itemType == ItemType.Equipment)
            SetEquipmentItem(_item);
        else if (_item.itemType == ItemType.Potion)
            SetPotionItem(_item);
        SetupButton();
        gameObject.SetActive(true);
    }

    private void SetNormalItem(ItemData _item)
    {
        item = _item;
        itemImage.sprite = item.icon;
        itemName.text = item.name;
        itemType.text = item.ItemType();
        itemDescription.text = item.itemDescription;
    }
    private void SetEquipmentItem(ItemData _item)
    {
        item = _item;
        ItemData_Equipment equipment = _item as ItemData_Equipment;
        itemImage.sprite = equipment.icon;
        itemName.text = equipment.name;
        itemType.text = equipment.ItemType();
        itemDescription.text = equipment.Description();
    }

    private void SetPotionItem(ItemData _item)
    {
        item = _item;
        ItemData_Potion potion = _item as ItemData_Potion;
        itemImage.sprite = potion.icon;
        itemName.text = potion.name;
        itemType.text = potion.ItemType();
        itemDescription.text = potion.Description();
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
        if(item.itemType == ItemType.Equipment)
            Inventory.instance.Equip(item);
        CloseItemInfo();
    }

    public void RemoveItem()
    {
        Inventory.instance.RemoveItem(item);
        CloseItemInfo();
    }

    public void UsePotion()
    {
        Inventory.instance.UsePotion(item);
    }

    public void MoveToSlot()
    {
        Inventory.instance.SetPotion(item);
    }
    public void SetupButton()
    {
        if (item.itemType == ItemType.Item)
        {
            foreach (var button in buttons)
            {
                if (button.name == "BtnClose" || button.name == "BtnRemove")
                    button.gameObject.SetActive(true);
                else
                    button.gameObject.SetActive(false);
            }
        }
        else if (item.itemType == ItemType.Equipment)
        {
            foreach (var button in buttons)
            {
                if (button.name == "BtnClose" || button.name == "BtnRemove"|| button.name == "BtnEquip")
                    button.gameObject.SetActive(true);
                else
                    button.gameObject.SetActive(false);
            }
        }
        else if (item.itemType == ItemType.Potion)
        {
            foreach (var button in buttons)
            {
                if (button.name == "BtnClose" || button.name == "BtnRemove" || button.name == "BtnUse" || button.name == "BtnMoveToSlot")
                    button.gameObject.SetActive(true);
                else
                    button.gameObject.SetActive(false);
            }
        }
    }
}
