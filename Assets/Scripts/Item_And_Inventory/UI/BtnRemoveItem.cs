using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnRemoveItem : BaseButton
{
    protected override void OnClick()
    {
        UI_ItemInfo.instance.RemoveItem();
    }
}
