using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState currentState;
    public void InitialState(EnemyState _state)
    {
        currentState = _state;
        currentState.Enter();
    }
    public void ChangeState(EnemyState _state)
    {
        currentState.Exit();
        currentState = _state;
        currentState.Enter();
    }
}
