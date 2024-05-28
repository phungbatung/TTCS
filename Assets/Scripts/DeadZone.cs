using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("deadzone");
        Player player = collision.gameObject.GetComponent<Player>();
        if (player!=null)
        {
            player.stats.Die();
        }    
    }
}
