using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeadBattleState : BringerOfDeadState
{
    public BringerOfDeadBattleState(Enemy_BringerOfDead _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
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
        if ((enemy.transform.position.x < PlayerManager.instance.player.transform.position.x && enemy.facingDir == -1)
            || (enemy.transform.position.x > PlayerManager.instance.player.transform.position.x && enemy.facingDir == 1))
        {
            enemy.Flip();
        }
        if (Vector2.Distance(enemy.transform.position, PlayerManager.instance.transform.position) > Mathf.Abs(enemy.transform.position.x - enemy.attackPoint.position.x))
            enemy.SetVelocity(1.5f * enemy.facingDir * enemy.moveSpeed, 0);
        else
            enemy.ZeroVelocity();
        if (!enemy.IsPlayerInZone())
            stateMachine.ChangeState(enemy.moveState);

        if (enemy.PlayerDetected())
            stateMachine.ChangeState(enemy.attackState);
        else if (enemy.CanBeUseUltimate())
            stateMachine.ChangeState(enemy.ultimateState);
        else if (enemy.CanBeUseTeleport() && Vector2.Distance(enemy.transform.position, PlayerManager.instance.player.transform.position) > 15)
            stateMachine.ChangeState(enemy.teleportState);
    }
}
