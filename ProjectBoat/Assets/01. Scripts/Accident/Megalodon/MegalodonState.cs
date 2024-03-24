using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MegalodonStateType
{
    Chase,
    Threat,
    Attack,
    Run
}

public class MegalodonState : State<MegalodonFSM, MegalodonStateType>
{
    protected Transform targetShipTrm;
    protected Transform ownerTrm;

    public MegalodonState(MegalodonFSM _owner, StateMachine<MegalodonFSM, MegalodonStateType> _stateMachine, string _animationBoolName) 
        : base(_owner, _stateMachine, _animationBoolName)
    {
        targetShipTrm = owner.targetShip.transform;
        ownerTrm = owner.transform;
    }

    public override void Update()
    {
        base.Update();

        owner.Movement.Move();
    }
}
