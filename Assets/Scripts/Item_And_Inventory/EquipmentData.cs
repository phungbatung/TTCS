using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Chestplate,
    Gauntlets,
    Pants,
    Boots,
    Weapon
}
[CreateAssetMenu(fileName = "New Equipment Data", menuName = "Data/Equipment")]
public class EquipmentData : ItemData
{
    public EquipmentType equipmentType;

    [Header("Major stats")]
    public int strength; // 1 point increase damage by 1 and crit power by 1%
    public int agility;  // 1 point increase evasion by 1% and crit chance by 1%
    public int vitality; // 1 point increase health by 3 or 5 points

    [Header("Offensive stats")]
    public int damage; // Weapon
    public int critChance; // Gaunlets
    public int critPower; // Helmet


    [Header("Defensive stats")]
    public int maxHealth; // Pants
    public int armor; // Chestplate
    public int evasion; // Boots

    public void AddModifier()
    {
        CharacterStats stats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        stats.strength.addModifier(strength);
        stats.agility.addModifier(agility);
        stats.vitality.addModifier(vitality);
        stats.damage.addModifier(damage);
        stats.critChance.addModifier(critChance);
        stats.critPower.addModifier(critPower);
        stats.maxHealth.addModifier(maxHealth);
        stats.armor.addModifier(armor);
        stats.evasion.addModifier(evasion);
    }
    
    public void RemoveModifier()
    {
        CharacterStats stats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        stats.strength.removeModifier(strength);
        stats.agility.removeModifier(agility);
        stats.vitality.removeModifier(vitality);
        stats.damage.removeModifier(damage);
        stats.critChance.removeModifier(critChance);
        stats.critPower.removeModifier(critPower);
        stats.maxHealth.removeModifier(maxHealth);
        stats.armor.removeModifier(armor);
        stats.evasion.removeModifier(evasion);
    }

    public override string Description()
    {
        string description = "";
        if (strength != 0) description += $"Strength + {strength}/n";
        if (agility != 0) description += $"Agility + {agility}/n";
        if (vitality != 0) description += $"Vitality + {vitality}/n";
        if (damage != 0) description += $"Damage + {damage}/n";
        if (critChance != 0) description += $"Crit Chance + {critChance}%/n";
        if (critPower != 0) description += $"Crit Power + {critPower}%/n";
        if (maxHealth != 0) description += $"Max Health + {maxHealth}/n";
        if (armor != 0) description += $"Armor + {armor}/n";
        if (evasion != 0) description += $"Evasion + {evasion}/n";

        description += base.Description();

        return description;
    }
}
