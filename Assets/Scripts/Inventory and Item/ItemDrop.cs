using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<ItemData> itemDrops;

    
    public void Drop()
    {
        foreach(var item in itemDrops)
        {
            if (UnityEngine.Random.Range(0, 100) <= item.dropRate)
            {
                GameObject newItemDrop= prefab.Spawn();
                newItemDrop.transform.position = transform.position;
                newItemDrop.GetComponent<ItemObject>().SetUpItem(item, new Vector2(UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(15, 20)));
            }    
        }    
    }    
}
