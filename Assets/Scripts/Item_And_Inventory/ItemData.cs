using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    Item,
    Equipment
}
[CreateAssetMenu(fileName = "New Item Data", menuName ="Data/Item")]
public class ItemData : ScriptableObject
{
    public ItemType itemtype;
    public Sprite icon;
    public string itemName;

}
