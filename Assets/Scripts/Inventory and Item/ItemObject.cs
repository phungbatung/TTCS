using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemData item;
    [SerializeField] private Rigidbody2D rb;

    private void OnValidate()
    {
        if (item == null)
            return;
        GetComponent<SpriteRenderer>().sprite = item.icon;
        gameObject.name = item.itemName;
    }

    public void SetUpItem(ItemData _item, Vector2 _velocity)
    {
        item=_item;
        GetComponent<SpriteRenderer>().sprite = item.icon;
        gameObject.name = item.itemName;
        rb.velocity = _velocity;
    }   
    
    public void PickUpItem()
    {
        Inventory.instance.AddItem(item);
        Destroy(gameObject);
    }    
}
