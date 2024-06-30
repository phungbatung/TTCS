using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpinningSwordController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Player player;
    private int moveDir;
    private float moveSpeed;
    private float maxDistance;
    private Vector2 startPosition;
    private bool isReturning = false;
    private int boomarangDamage;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        player = PlayerManager.instance.player;
    }

    public void SetUpSword(Transform _transform, int _moveDir, float _moveSpeed, float _maxDistance, int _damage)
    {
        transform.position = _transform.position;
        startPosition = _transform.position;
        boomarangDamage = _damage;
        moveDir = _moveDir;
        moveSpeed = _moveSpeed;
        maxDistance = _maxDistance;
    }
    private void Update()
    {
        BoomerangLogic();

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
        if (enemy == null)
        {
            isReturning = true;
            rb.velocity = Vector2.zero;
        }
        else
            enemy.stats.TakeDamage(boomarangDamage);
       
    }
    public void OnSpawn()
    {
    }
    public void OnPreDisable()
    {
        isReturning = false;
    }
}
