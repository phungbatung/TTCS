using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_HatMan : NPC
{
    [SerializeField] UI_EquipmentShop equipmentShop;
    protected override void ExcuteEvent()
    {
        equipmentShop.Toggle();
    }
}
