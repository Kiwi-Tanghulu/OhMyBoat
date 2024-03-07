using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T, U> where T : class where U : Enum
{
    protected StateMachine<T, U> stateMachine;
    protected T owner;

    protected int animBoolHash;
    protected bool triggerCalled;
    public State(T _owner, StateMachine<T, U> _stateMachine, string _animationBoolName)
    {
        owner = _owner;
        stateMachine = _stateMachine;
        animBoolHash = Animator.StringToHash(_animationBoolName);
    }
    public virtual void Enter() 
    {
        triggerCalled = false;
    }

    public virtual void Update() { }

    public virtual void Exit() { }
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
