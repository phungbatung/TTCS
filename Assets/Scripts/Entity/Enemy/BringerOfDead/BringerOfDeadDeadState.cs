using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeadDeadState : BringerOfDeadState
{
    public BringerOfDeadDeadState(Enemy_BringerOfDead _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.GetComponent<ItemDrop>().Drop();
        enemy.cd.enabled = false;
        enemy.rb.constraints = RigidbodyConstraints2D.FreezeAll;
        enemy.wasDead = false;
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
            enemy.Destroy();
    }
}
