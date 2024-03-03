using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    
    
    public float jumpForce;
    public float dashSpeed;
    public float dashDuration;
    public int dashDir;
    public float dashCooldown;
    [HideInInspector]public float lastTimeDash;
    

    private PlayerStateMachine stateMachine;
    public PlayerIdleState idleState;
    public PlayerMoveState moveState;
    public PlayerJumpState jumpState;
    public PlayerAirState airState;
    public PlayerWallSlideState wallSlide;
    public PlayerWallJumpState wallJump;
    public PlayerDashState dashState;
    public PlayerPrimaryAttack primaryAttack;

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
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

    
    protected override void Update()
    {
        stateMachine.currentState.Update();
    }
    
    
    public void TriggerCalled()
    {
        stateMachine.currentState.TriggerCalled();
    }

    
}
