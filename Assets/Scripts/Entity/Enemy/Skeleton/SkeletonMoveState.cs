using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : SkeletonGroundedState
{
    public SkeletonMoveState(Enemy_Skeleton _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
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
        enemy.SetVelocity(enemy.facingDir * enemy.moveSpeed, enemy.rb.velocity.y);
        if (enemy.IsWallDetected() || !enemy.IsGrounded())
        {
            enemy.Flip();
            enemy.ZeroVelocity();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
