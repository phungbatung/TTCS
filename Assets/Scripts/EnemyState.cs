using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected string animBoolName;

    protected float stateTimer;
    protected bool isTrigger;
    public EnemyState(EnemyStateMachine _stateMachine, string _animBoolName)
    {
        stateMachine = _stateMachine;
        animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {

    }
    public virtual void Exit()
    {

    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
    public virtual void TriggerCalled()
    {
        isTrigger = true;
    }
}
