using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D cd;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        cd=GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    {
        transform.up = -rb.velocity;
    }
}
