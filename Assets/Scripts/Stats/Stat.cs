using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]private int baseValue;
    [SerializeField]private List<int> modifiers;

    public int getValue()
    {
        int value = baseValue;
        foreach (int modifier in modifiers)
        {
            value += modifier;
        }
        return value;
    }
    public void addModifier(int modifier)
    {
        modifiers.Add(modifier);
        UI_Stats.instance.UpdateStatsUI();
    }
    public void removeModifier(int modifier) 
    { 
        modifiers.Remove(modifier);
        UI_Stats.instance.UpdateStatsUI();
    }
    public void SetDefaultValue(int _value)
    {
        baseValue = _value;
    }
}
