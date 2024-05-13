using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGroundedState : SkeletonState
{
    public SkeletonGroundedState(Enemy_Skeleton _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
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
        if (enemy.PlayerDetected())
        {
            Transform player = enemy.PlayerDetected().transform;
            if((player.position.x - enemy.transform.position.x) * enemy.facingDir < 0)
            {
                enemy.Flip();
            }
            stateMachine.ChangeState(enemy.attackState);
        }
        
    }
}
