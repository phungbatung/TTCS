using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{

    [Header("Dash info")]
    public float dashSpeed;
    public float dashDuration;
    public int dashDir;
    public float dashCooldown;
    [HideInInspector]public float lastTimeDash;

    #region PlayerState
    private PlayerStateMachine stateMachine;
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerWallSlideState wallSlide { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerPrimaryAttack primaryAttack { get; private set; }
    #endregion

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
