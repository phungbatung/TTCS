using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(xInput * player.moveSpeed, player.rb.velocity.y);

        if (xInput == 0)
            stateMachine.ChangeState(player.idleState);
        if (!player.IsGrounded())
            stateMachine.ChangeState(player.airState);
        if (player.IsWallDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
