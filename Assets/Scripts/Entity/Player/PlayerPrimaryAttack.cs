using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    private int attackCounter = 0;
    private float lastTimeAttacked;
    public PlayerPrimaryAttack(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {

        base.Enter();
        if (Time.time - lastTimeAttacked > 2 || attackCounter >= 3) //Check for reset combo
            attackCounter = 0;

        player.SetVelocity(player.facingDir * player.attackMovement[attackCounter].x, player.attackMovement[attackCounter].y);
        player.anim.SetInteger("AttackCounter", attackCounter);
        attackCounter++;
    }

    public override void Exit()
    {
        base.Exit();
        lastTimeAttacked = Time.time;
        isTrigger = false;
        /*player.StartCoroutine("BusyFor", 0.15f);*/
    }

    public override void Update()
    {
        base.Update();
        if (isTrigger)
            stateMachine.ChangeState(player.idleState);
    }
}
