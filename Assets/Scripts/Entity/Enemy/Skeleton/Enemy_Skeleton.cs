using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : Enemy
{
    public SkeletonIdleState idleState { get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SkeletonAttackState attackState { get; private set; }
    public SkeletonDeadState deadState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        idleState = new SkeletonIdleState(this, stateMachine, "Idle");
        moveState = new SkeletonMoveState(this, stateMachine, "Move");
        attackState = new SkeletonAttackState(this, stateMachine, "Attack");
        deadState = new SkeletonDeadState(this, stateMachine, "Dead");
        stateMachine.InitialState(idleState);

    }

    protected override void Update()
    {
        base.Update();
    }
    
}
