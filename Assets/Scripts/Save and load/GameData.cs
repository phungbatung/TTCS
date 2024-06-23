using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    public int gold;
    public int diamond;
    public SerializableDictionary<string, int> inventory;
    public List<string> equipmentId;
    public string currentPotion;

    public GameData()
    {
        inventory = new SerializableDictionary<string, int>();
        equipmentId = new List<string>();
    }

}
