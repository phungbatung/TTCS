using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected string animBoolName;
    protected float xInput = 0;

    protected float stateTimer;
    protected bool isTrigger = false;

    public PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName)
    {
        stateMachine = _stateMachine;
        player = _player;
        animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
    }
    public virtual void Exit() 
    {
        player.anim.SetBool(animBoolName, false);
    }
    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("yVelocity", player.rb.velocity.y);
        stateTimer -= Time.deltaTime;
        if (player.isBusy)
            player.ZeroVelocity();
        if (Input.GetKeyDown(KeyCode.Q) && SkillManager.instance.rageModeSkill.CanBeUse())
            SkillManager.instance.rageModeSkill.SetUpRage();
        CheckForDash();
    }
    protected virtual void CheckForDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && (Time.time-player.lastTimeDash) > player.dashCooldown)
        {
            player.dashDir = player.facingDir;
            if (player.IsWallDetected() && !player.IsGrounded()) 
                player.dashDir = -player.facingDir;
            stateMachine.ChangeState(player.dashState);
        }
    }
    public virtual void TriggerCalled()
    {
        isTrigger = true;
    }
}
