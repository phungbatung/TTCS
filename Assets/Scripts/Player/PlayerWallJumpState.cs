using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }
    private float uncontrollableTime=.15f;
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(-player.facingDir * player.moveSpeed, player.jumpForce);
        stateTimer = uncontrollableTime;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (stateTimer < 0)
            player.SetVelocity(xInput * player.moveSpeed, player.rb.velocity.y);
        base.Update();
        if (player.rb.velocity.y <= 0)
            stateMachine.ChangeState(player.airState);
    }
}
