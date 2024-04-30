using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BtnCharacterPanel : BaseButton
{
    
    protected override void OnClick()
    {
        UI_Menus.instance.Toggle();
    }
}
