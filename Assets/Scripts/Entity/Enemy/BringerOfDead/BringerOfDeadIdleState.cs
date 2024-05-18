using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeadIdleState : BringerOfDeadState
{
    public BringerOfDeadIdleState(Enemy_BringerOfDead _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.ZeroVelocity();
        stateTimer = .75f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer <= 0)
            stateMachine.ChangeState(enemy.moveState);
    }
}
