using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;
    public bool isFacingRight;
    public int facingDir;
    public float dashSpeed;
    public float dashDuration;
    public int dashDir;
    public float dashCooldown;
    [HideInInspector]public float lastTimeDash;

    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    public bool grounded;

    [SerializeField] private Transform wallCheckPoint;
    [SerializeField] private float walllCheckDistance;


    public Animator anim;
    public Rigidbody2D rb;

    private PlayerStateMachine stateMachine;
    public PlayerIdleState idleState;
    public PlayerMoveState moveState;
    public PlayerJumpState jumpState;
    public PlayerAirState airState;
    public PlayerWallSlideState wallSlide;
    public PlayerWallJumpState wallJump;
    public PlayerDashState dashState;
    public PlayerPrimaryAttack primaryAttack;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(stateMachine, this, "Idle");
        moveState = new PlayerMoveState(stateMachine, this, "Move");
        jumpState = new PlayerJumpState(stateMachine, this, "Jump");
        airState = new PlayerAirState(stateMachine, this, "Jump");
        wallSlide = new PlayerWallSlideState(stateMachine, this, "WallSlide");
        wallJump = new PlayerWallJumpState(stateMachine, this, "Jump");
        dashState = new PlayerDashState(stateMachine, this, "Dash");
        primaryAttack = new PlayerPrimaryAttack(stateMachine, this, "Attack");

        stateMachine.InitialState(idleState);
    }

    
    void Update()
    {
        stateMachine.currentState.Update();
        grounded=IsGrounded();
        
    }
    public void TriggerCalled()
    {
        stateMachine.currentState.TriggerCalled();
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
        facingDir = -1*facingDir;
    }
    private void FlipController(float x)
    {
        if (x > 0 && !isFacingRight)
            Flip();
        if (x < 0 && isFacingRight)
            Flip();
    }

    public void SetVelocity(float _x, float _y)
    {
        rb.velocity = new Vector2(_x, _y);
        FlipController(_x);
    }

    public void ZeroVelocity()
    {
        rb.velocity = Vector2.zero;
    }

    public bool IsGrounded()
    {
        return Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    public bool IsWallDetected()
    {
        return Physics2D.Raycast(wallCheckPoint.position, Vector2.right, facingDir*walllCheckDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheckPoint.position, new Vector2(groundCheckPoint.position.x, groundCheckPoint.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheckPoint.position, new Vector2(wallCheckPoint.position.x + facingDir * walllCheckDistance, wallCheckPoint.position.y));
    }
    
}
