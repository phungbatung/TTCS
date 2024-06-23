using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
        player.SpawnDashDust();
        player.stats.isImmortal = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.ZeroVelocity();
        player.lastTimeDash = Time.time;
        player.stats.isImmortal = false;
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(player.dashDir * player.dashSpeed, 0);
        if (stateTimer <= 0)
            stateMachine.ChangeState(player.idleState);
    }

    protected override void CheckForDash()
    {
    }
}
