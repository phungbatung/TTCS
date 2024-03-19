using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private void Awake()
    {
        anim=GetComponentInChildren<Animator>();
        rb=GetComponent<Rigidbody2D>();
        cd=GetComponent<CircleCollider2D>();
    }

    public void SetUpSword(Transform _transform, Vector2 _direction, float _gravity)
    {
        transform.position =_transform.position;
        rb.velocity = _direction;
        rb.gravityScale = _gravity;
    }
    private void Update()
    {
        if (rb.velocity!=Vector2.zero)
            transform.right = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        cd.enabled = false;

        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        transform.parent = collision.transform;
    }
}
