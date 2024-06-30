using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ItemInfoInventory : UI_ItemInfo
{
    protected BaseButton[] buttons;
    protected override void Awake()
    {
        buttons = GetComponentsInChildren<BaseButton>();
        base.Awake();
    }
    public override void SetItemInfo(ItemData _item)
    {
        base.SetItemInfo(_item);
        SetupButton();
    }
    public virtual void SetupButton()
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
                if (button.name == "BtnClose" || button.name == "BtnRemove" || button.name == "BtnEquip")
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
