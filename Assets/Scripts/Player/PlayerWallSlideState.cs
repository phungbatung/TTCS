using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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
        player.SetVelocity(0, -.5f);
        if (player.IsGrounded())
            stateMachine.ChangeState(player.idleState);
        if (xInput*player.facingDir == -1||!player.IsWallDetected())
            stateMachine.ChangeState(player.airState);
        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.ChangeState(player.wallJump);

    }
}
