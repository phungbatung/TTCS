using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeadUltimateState : BringerOfDeadState
{
    public BringerOfDeadUltimateState(Enemy_BringerOfDead _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.ultimateTimer = enemy.ultimateCooldown;
        isTrigger = false;
    }

    public override void Update()
    {
        base.Update();
        if (isTrigger)
            stateMachine.ChangeState(enemy.idleState);
    }
}
