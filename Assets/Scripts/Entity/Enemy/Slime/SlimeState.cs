using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeState : EnemyState
{
    protected Enemy_Slime enemy;
    public SlimeState( Enemy_Slime _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_stateMachine, _animBoolName)
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
    }
}
