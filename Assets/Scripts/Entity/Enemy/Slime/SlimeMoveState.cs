using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoveState : SlimeState
{
    public SlimeMoveState(Enemy_Slime _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
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
        enemy.SetVelocity(enemy.facingDir * enemy.moveSpeed, 0);
        if (!enemy.IsGrounded() || enemy.IsWallDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
        if (enemy.PlayerDetected())
        {
            Transform player = enemy.PlayerDetected().transform;
            if ((player.position.x - enemy.transform.position.x) * enemy.facingDir < 0)
            {
                enemy.Flip();
            }
            stateMachine.ChangeState(enemy.jumpState);
        }
    }
}
