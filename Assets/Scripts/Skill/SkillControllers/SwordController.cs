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
    private float destroyTimer;

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
            BoomerangLogic();
        else
            NormalLogic();

    }

    private void NormalLogic()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
            gameObject.Despawn();
        if (rb.velocity != Vector2.zero)
            transform.right = rb.velocity;
    }

    private void BoomerangLogic()
    {
        if (isReturning)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, player.transform.position) < .5f)
                gameObject.Despawn();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
            enemy.DamagedEffect();
        if (isBoomarang)
        {
            if (enemy == null)
            {
                isReturning = true;
                rb.velocity = Vector2.zero;
            }
            return;
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
        isReturning = false;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.constraints = RigidbodyConstraints2D.None;
    }
}
