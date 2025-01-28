using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThunderSwordController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private float destroyTimer;
    private float moveDir;
    private float velocity;
    private float acceleration;
    private Vector3 startPosition;
    private float maxDistance;
    private int damage;
    public bool canBeDestroy;
    private Player player;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        player = PlayerManager.instance.player;
        canBeDestroy = true;
    }

    public void SetUpSword(Transform _transform, float _gravity, float _moveDir, float _velocity, float _acceleration, float _maxDistance, int _damage)
    {
        transform.position = _transform.position;
        startPosition = _transform.position;
        rb.gravityScale = _gravity;
        damage = _damage;
        moveDir = _moveDir;
        velocity = _velocity;
        acceleration = _acceleration;
        maxDistance = _maxDistance;
        destroyTimer = 3.0f;
    }
    private void Update()
    {
        velocity += acceleration * Time.deltaTime;
        rb.velocity = new Vector3 ( moveDir * velocity, 0, 0);
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0 && canBeDestroy)
            gameObject.Despawn();
        if (rb.velocity != Vector2.zero)
            transform.right = rb.velocity;
        if (Vector3.Distance(startPosition, transform.position) > maxDistance)
            gameObject.Despawn();
    }

    private void OnDisable()
    {
        SkillManager.instance.flyThunderGodSkill.canBeUseSkill = true;
        SkillManager.instance.flyThunderGodSkill.canBeTeleport = false;
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

        SkillManager.instance.flyThunderGodSkill.canBeTeleport = true;
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
        canBeDestroy = true;
    }
}
