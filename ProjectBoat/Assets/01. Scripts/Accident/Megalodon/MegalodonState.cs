using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MegalodonStateType
{
    Move,
    Chase,
    Threat,
    Attack,
    Run
}

public class MegalodonState : State<MegalodonFSM, MegalodonStateType>
{
    public MegalodonState(MegalodonFSM _owner, StateMachine<MegalodonFSM, MegalodonStateType> _stateMachine, string _animationBoolName) 
        : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        owner.Movement.Move();
    }
}
