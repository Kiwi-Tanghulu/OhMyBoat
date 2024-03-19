using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonRunState : MegalodonState
{
    public MegalodonRunState(MegalodonFSM _owner, StateMachine<MegalodonFSM, MegalodonStateType> _stateMachine, string _animationBoolName) 
        : base(_owner, _stateMachine, _animationBoolName)
    {
    }
}
