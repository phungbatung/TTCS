using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackState : SlimeState
{
    public SlimeAttackState(Enemy_Slime _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
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
        if (Mathf.Abs(enemy.rb.velocity.y) <= .1f)
        {
            enemy.ZeroVelocity();
            Attack();
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    private void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackPoint.position, enemy.attackRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                enemy.stats.DoDamage(hit.GetComponent<CharacterStats>());
            }
        }
    }
}
