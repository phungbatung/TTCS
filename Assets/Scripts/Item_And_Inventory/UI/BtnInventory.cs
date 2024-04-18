using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BtnInventory : BaseButton
{
    protected override void OnClick()
    {
        Inventory_UI.instance.Toggle();
    }
}
