using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BtnBuyingItem : BaseButton
{
    private UI_ItemInfo itemInfo;
    private TextMeshProUGUI priceUI;
    protected override void Awake()
    {
        base.Awake();
        itemInfo = GetComponentInParent<UI_ItemInfo>();
        priceUI = GetComponentInChildren<TextMeshProUGUI>();
    }
    protected override void OnClick()
    {
        int price = Int32.Parse(priceUI.text.Substring(7));
        Inventory.instance.BuyingThisItem(itemInfo.item, price);
    }
}
