using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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
        if (player.IsGrounded())
            stateMachine.ChangeState(player.idleState);
        if (player.IsWallDetected())
            stateMachine.ChangeState(player.wallSlide);
        if (Input.GetKeyDown(KeyCode.Space) && player.canDoubleJump)
        {
            stateMachine.ChangeState(player.jumpState);
            player.canDoubleJump = false;
        }
    }
}
