using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateEnum
{
    Idle,
    Move,
    Jump,
    Fall,
    Swim,
}
public class StateMachine<T, U> where T : class where U : Enum
{
    private T stateMachineClass;
    public State<T, U> CurrentState { get; private set; }
    public Dictionary<U, State<T, U>> StateDictionary = new Dictionary<U, State<T, U>>();

    private T owner;

    public void Initialize(U startState, T _owner)
    {
        owner = _owner;
        CurrentState = StateDictionary[startState];
        CurrentState.Enter();
    }
    public void ChangeState(U nextStateType)
    {
        CurrentState.Exit();
        CurrentState = StateDictionary[nextStateType];
        CurrentState.Enter();
    }

    public void AddState(U type, State<T, U> state)
    {
        StateDictionary.Add(type, state);
    }
}
