using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowSpinSword : PlayerState
{
    public PlayerThrowSpinSword(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        isTrigger = false;
    }

    public override void Update()
    {
        base.Update();
        if (isTrigger)
            stateMachine.ChangeState(player.idleState);
    }
}
