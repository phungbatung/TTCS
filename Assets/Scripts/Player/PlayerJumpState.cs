using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }
    private bool canDoubleJump = true;
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
        if (!canDoubleJump)
            canDoubleJump = true;
    }

    public override void Update()
    {
        base.Update();
        player.SetVelocity(xInput * player.moveSpeed, player.rb.velocity.y);
        if (player.rb.velocity.y <= 0)
            stateMachine.ChangeState(player.airState);
        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
        {
            stateMachine.ChangeState(player.jumpState);
            canDoubleJump = false;
        }
    }
}
