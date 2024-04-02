using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : Enemy
{

    public Transform playerCheck;
    public LayerMask playerLayer;
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
    public RaycastHit2D PlayerDetected()
    {
        return Physics2D.Raycast(playerCheck.position, Vector2.right, 2 * (transform.position.x - playerCheck.position.x), playerLayer);
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerCheck.position, new Vector2(playerCheck.position.x + 2 * (transform.position.x - playerCheck.position.x), playerCheck.position.y));
    }

    public virtual void AnimationTriggerCalled()
    {
        stateMachine.currentState.TriggerCalled();
    }
}
