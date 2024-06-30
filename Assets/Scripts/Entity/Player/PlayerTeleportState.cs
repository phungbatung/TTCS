using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportState : PlayerState
{
    public PlayerTeleportState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = Mathf.Infinity;
        if (player.transform.position.x < SkillManager.instance.flyThunderGodSkill.swordScript.transform.position.x && player.facingDir == -1)
            player.Flip();
        if (player.transform.position.x > SkillManager.instance.flyThunderGodSkill.swordScript.transform.position.x && player.facingDir == 1)
            player.Flip();
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("OnTeleport", false);
    }

    public override void Update()
    {
        base.Update();
        if (isTrigger)
        {
            isTrigger = false;
            player.anim.SetBool("OnTeleport", true);
            stateTimer = .1f;
        }
        if (stateTimer <= 0)
        {
            Debug.Log("idle");
            stateMachine.ChangeState(player.idleState);
        }
    }
}
