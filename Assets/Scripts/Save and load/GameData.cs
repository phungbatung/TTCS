using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    public SerializableDictionary<string, int> inventory;
    public List<string> equipmentId;

    public GameData()
    {
        inventory = new SerializableDictionary<string, int>();
        equipmentId = new List<string>();
    }

}
