using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Components info")]
    public Animator anim;
    public Rigidbody2D rb;
    public EntityFX entityFX;

    [Header("Movement info")]
    public float moveSpeed;
    public bool isFacingRight;
    public int facingDir;
    public bool isBusy;
    public float jumpForce;

    [Header("Ground check")]
    [SerializeField] protected Transform groundCheckPoint;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask groundLayer;

    [Header("Wall check")]
    [SerializeField] protected Transform wallCheckPoint;
    [SerializeField] protected float walllCheckDistance;

    [Header("Attack info")]
    public Transform attackPoint;
    public float attackRadius;
    public Vector2[] attackMovement;

    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        entityFX = GetComponent<EntityFX>();
    }
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
        facingDir = -1 * facingDir;
    }

    protected virtual void FlipController(float x)
    {
        if (x > 0 && !isFacingRight)
            Flip();
        if (x < 0 && isFacingRight)
            Flip();
    }

    public virtual void SetVelocity(float _x, float _y)
    {
        rb.velocity = new Vector2(_x, _y);
        FlipController(_x);
    }
    public virtual void ZeroVelocity()
    {
        rb.velocity = Vector2.zero;
    }

    public virtual bool IsGrounded() => Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckDistance, groundLayer);
    

    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheckPoint.position, Vector2.right, facingDir * walllCheckDistance, groundLayer);

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckPoint.position, new Vector2(groundCheckPoint.position.x, groundCheckPoint.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheckPoint.position, new Vector2(wallCheckPoint.position.x + facingDir * walllCheckDistance, wallCheckPoint.position.y));
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public virtual void Damaged()
    {
        Debug.Log($"{gameObject.name} is Damaged");
        entityFX.StartCoroutine("FlashFX");

    }


    public virtual IEnumerator BusyFor(float _time)
    {
        isBusy = true;
        yield return new WaitForSeconds(_time);
        isBusy = false;
    }
}
