using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Transform playerCheck;
    public LayerMask playerLayer;

    public EnemyStateMachine stateMachine { get; private set; }
    public bool wasDead = false;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }
    public virtual void Destroy()
    {
        Destroy(gameObject);
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
