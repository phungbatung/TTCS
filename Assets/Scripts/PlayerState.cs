using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected string animBoolName;
    protected float xInput = 0;
    public PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName)
    {
        stateMachine = _stateMachine;
        player = _player;
        animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
    }
    public virtual void Exit() 
    {
        player.anim.SetBool(animBoolName, false);
    }
    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("yVelocity", player.rb.velocity.y);
    }
}
