using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum ItemType
{
    Item,
    Equipment
}
[CreateAssetMenu(fileName = "New Item Data", menuName ="Data/Items")]
public class ItemData : ScriptableObject
{
    public string itemId;
    public ItemType itemtype;
    public Sprite icon;
    public string itemName;
    public string itemDescription;
    [Range(1, 100)]
    public int dropRate;

    private void OnValidate()
    {
#if UNITY_EDITOR
        string path = AssetDatabase.GetAssetPath(this);
        itemId = AssetDatabase.AssetPathToGUID(path);
#endif
    }
    public virtual string Description()
    {
        return itemDescription;
    }
}
