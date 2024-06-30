using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private float destroyTimer;
    private int damage;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    public void SetUpSword(Transform _transform, float _gravity, Vector2 _direction, int _damage)
    {
        transform.position = _transform.position;
        rb.gravityScale = _gravity;
        damage = _damage;
        rb.velocity = _direction;
        destroyTimer = 3.0f;
    }
    private void Update()
    {
        SwordLogic();
    }

    private void SwordLogic()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
            gameObject.Despawn();
        if (rb.velocity != Vector2.zero)
            transform.right = rb.velocity;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.DamagedEffect();
            enemy.stats.TakeDamage(damage);
        }
        box.enabled = false;
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.parent = collision.transform;
        destroyTimer = 2.5f;
    }
    public void OnSpawn()
    {
        destroyTimer = Mathf.Infinity;
    }
    public void OnPreDisable()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.constraints = RigidbodyConstraints2D.None;
        box.enabled = true;
    }
}
