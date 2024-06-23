using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnUse : BaseButton
{
    private UI_ItemInfo itemInfo;
    protected override void Awake()
    {
        base.Awake();
        itemInfo = GetComponentInParent<UI_ItemInfo>();
    }
    protected override void OnClick()
    {
        itemInfo.UsePotion();
    }
}
