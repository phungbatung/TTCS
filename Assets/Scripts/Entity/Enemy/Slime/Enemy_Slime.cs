using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Slime : Enemy
{

    public SlimeIdleState idleState;
    public SlimeMoveState moveState;
    public SlimeJumpState jumpState;
    public SlimeAttackState attackState;
    public SlimeDeadState deadState;
    protected override void Start()
    {
        base.Start();
        idleState = new SlimeIdleState(this, stateMachine, "idle");
        moveState = new SlimeMoveState(this, stateMachine, "move");
        jumpState = new SlimeJumpState(this, stateMachine, "jump");
        attackState = new SlimeAttackState(this, stateMachine, "attack");
        stateMachine.InitialState(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}
