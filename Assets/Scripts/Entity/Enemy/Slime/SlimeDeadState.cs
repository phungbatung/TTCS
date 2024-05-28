using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDeadState : SlimeState
{
    public SlimeDeadState(Enemy_Slime _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.GetComponent<ItemDrop>().Drop();
        stateTimer = 3f;
        enemy.cd.enabled = false;
        enemy.rb.constraints = RigidbodyConstraints2D.FreezeAll;
        enemy.wasDead = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer <= 0)
            enemy.Destroy();
    }
}
