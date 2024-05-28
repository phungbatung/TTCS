using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    [SerializeField] private ItemObject itemObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>()!=null)
        {
            itemObject.PickUpItem();
        }
    }
}
