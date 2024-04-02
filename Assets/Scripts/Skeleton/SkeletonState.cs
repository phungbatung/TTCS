using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonState : EnemyState
{
    protected Enemy_Skeleton enemy;
    public SkeletonState(Enemy_Skeleton _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.anim.SetBool(animBoolName, true);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.anim.SetBool(animBoolName, false);
    }

    public override void Update()
    {
        base.Update();
        if (enemy.wasDead)
            stateMachine.ChangeState(enemy.deadState);
    }
}
