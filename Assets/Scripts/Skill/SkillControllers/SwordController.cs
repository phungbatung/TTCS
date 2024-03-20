using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D circle;
    private BoxCollider2D box;
    private bool isBoomarang = false;
    private Player player;

    [Header("Normal mode info")]
    private Vector2 _direction;

    [Header("Boomarang mode info")]
    private int moveDir;
    private float moveSpeed;
    private float maxDistance;
    private Vector2 startPosition;
    private bool isReturning = false;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        box = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        player = PlayerManager.instance.player;
    }
    public void SetUpNormal(Vector2 _direction) => rb.velocity = _direction;
    public void SetUpBoomarang(int _moveDir, float _moveSpeed, float _maxDistance)
    {
        moveDir = _moveDir;
        moveSpeed = _moveSpeed;
        maxDistance = _maxDistance;
    }

    public void SetUpSword(Transform _transform, float _gravity, bool _isBoomarang)
    {
        transform.position = _transform.position;
        startPosition = _transform.position;
        rb.gravityScale = _gravity;
        isBoomarang = _isBoomarang;
        anim.SetBool("Spin", isBoomarang);

        box.enabled = !isBoomarang;
        circle.enabled = isBoomarang;
    }
    private void Update()
    {
        if (isBoomarang)
        {
            if (isReturning)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, player.transform.position) < .5f)
                    Destroy(gameObject);
            }
            else
            {
                rb.velocity = new Vector2(moveDir * moveSpeed, 0);
                if (Vector2.Distance(transform.position, startPosition) >= maxDistance)
                {
                    isReturning = true;
                    rb.velocity = Vector2.zero;
                }
            }
        }
        else
            if (rb.velocity != Vector2.zero)
            transform.right = rb.velocity;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Enemy>()?.Damaged();
        if (isBoomarang)
        {
            /*if (collision.gameObject.CompareTag("ground"))
                isReturning=true;*/
            return;
        }
        box.enabled = false;
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.parent = collision.transform;
    }
}
