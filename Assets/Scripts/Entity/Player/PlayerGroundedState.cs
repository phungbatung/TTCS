using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    protected bool isReturn = false;
    public override void Enter()
    {
        base.Enter();
        isReturn = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            stateMachine.ChangeState(player.jumpState);
        if (!player.IsGrounded())
            stateMachine.ChangeState(player.airState);
        /* if (Input.GetKeyDown(KeyCode.Mouse1))
         {
             stateMachine.ChangeState(player.aimSword);
             isReturn = true;
         }*/
        if (Input.GetKeyDown(KeyCode.E) && SkillManager.instance.flyThunderGodSkill.CanBeUse())
        {
            stateMachine.ChangeState(player.aimSword);
            isReturn = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && SkillManager.instance.boomarangSwordSkill.CanBeUse())
        {
            stateMachine.ChangeState(player.throwSword);
            isReturn = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(player.primaryAttack);
            isReturn = true;
        } 
    }
}
