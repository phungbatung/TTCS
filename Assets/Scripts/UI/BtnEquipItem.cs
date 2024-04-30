using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEquipItem : BaseButton
{
    protected override void OnClick()
    {
        UI_ItemInfo.instance.EquipItem();
    }
}
