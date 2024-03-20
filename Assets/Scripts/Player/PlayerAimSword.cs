using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerAimSword : PlayerState
{
    private bool boomarangMode=true;
    public PlayerAimSword(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        SkillManager.instance.throwSwordSkill.SwitchActiveDots(true);
        boomarangMode = SkillManager.instance.throwSwordSkill.isBoomarang;
    }
    private Vector2 mousePosition;
    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("Throw", false);
        isTrigger = false;
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyUp(KeyCode.Mouse1))
            player.anim.SetBool("Throw", true);
        if (Input.GetKeyUp(KeyCode.F))
            player.anim.SetBool("Throw", true);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(!boomarangMode)
            if ((mousePosition.x > player.transform.position.x && player.facingDir == -1) || (mousePosition.x < player.transform.position.x && player.facingDir == 1))
                player.Flip();

        if (isTrigger)
            stateMachine.ChangeState(player.idleState);
        
    }
}
