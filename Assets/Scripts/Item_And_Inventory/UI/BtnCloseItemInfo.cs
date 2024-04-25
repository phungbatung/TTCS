using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseItemInfo : BaseButton
{
    protected override void OnClick()
    {
        UI_ItemInfo.instance.CloseItemInfo();
    }
}
