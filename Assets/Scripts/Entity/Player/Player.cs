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

    [Header("Dust Effect")]
    public GameObject dashDustPrefab;
    public Vector2 dashPosition;
    public GameObject jumpDustPrefab;
    public Vector2 jumpPosition;

    #region PlayerState
    public  PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerWallSlideState wallSlide { get; private set; }
    public PlayerWallJumpState wallJump { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerPrimaryAttack primaryAttack { get; private set; }
    public PlayerAimSword aimSword { get; private set; }
    public PlayerDeadState deadState { get; private set; }
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
        aimSword = new PlayerAimSword(stateMachine, this, "Aim");
        deadState = new PlayerDeadState(stateMachine, this, "Dead");

        stateMachine.InitialState(idleState);
    }

    
    protected override void Update()
    {
        if ( Time.timeScale <= 0)
            return;
        stateMachine.currentState.Update();
    }
    
    
    public void TriggerCalled()
    {
        stateMachine.currentState.TriggerCalled();
    }

    public void IncreaseSpeedBy(float _speed)
    {
        moveSpeed += _speed;
    }
    public void DecreaseSpeedBy(float _speed)
    {
        moveSpeed -= _speed;
    }
    public void SpawnDashDust()
    {
        GameObject dashDust = dashDustPrefab.Spawn();
        dashDust.GetComponent<DustEffect>().SetUpDust(transform.position + (Vector3)dashPosition, facingDir);
    }    
    public void SpawnJumpDust()
    {
        GameObject jumpDust = jumpDustPrefab.Spawn();
        jumpDust.GetComponent<DustEffect>().SetUpDust(transform.position + (Vector3)jumpPosition, facingDir);
    }
}
