using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeJumpState : SlimeState
{
    public SlimeJumpState(Enemy_Slime _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
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
        {
            stateMachine.ChangeState(enemy.attackState);
        }
    }
}
