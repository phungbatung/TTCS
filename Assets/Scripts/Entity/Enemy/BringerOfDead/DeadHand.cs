using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadHand : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private Vector2 size;
    [SerializeField] private int damage;
    private bool wasDoDamage;
    private void Awake()
    {
        wasDoDamage = false;
    }

    private void Attack()
    {
        if (wasDoDamage)
            return;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(point.position, size, 0);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                hit.GetComponent<Player>().stats.TakeDamage(damage);
                wasDoDamage = true;
            }
        }
    }

    private void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(point.position, size);
    }
}
