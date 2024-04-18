using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData item;
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = item.icon;
        gameObject.name = item.itemName;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory.instance.AddItem(item);
        Destroy(gameObject);
    }
}
