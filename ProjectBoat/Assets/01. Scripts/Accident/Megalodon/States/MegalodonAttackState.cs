using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonAttackState : MegalodonState
{
    public MegalodonAttackState(MegalodonFSM _owner, StateMachine<MegalodonFSM, MegalodonStateType> _stateMachine, string _animationBoolName) 
        : base(_owner, _stateMachine, _animationBoolName)
    {
    }
}
