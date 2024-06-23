using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion Data", menuName = "Data/Potion")]
public class ItemData_Potion : ItemData
{
    public int healthHeals;

    public override string Description()
    {
        string description = $"Instantly heals {healthHeals} Health";
        return description;
    }

    public void Healing()
    {
        PlayerManager.instance.player.GetComponent<CharacterStats>().Healing(healthHeals);
    }
}
