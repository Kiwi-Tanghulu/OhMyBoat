using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonChaseState : MegalodonState
{
    private Transform targetShipTrm;
    private Transform ownerTrm;

    private float threatRadius;

    public MegalodonChaseState(MegalodonFSM _owner, StateMachine<MegalodonFSM, MegalodonStateType> _stateMachine, string _animationBoolName) 
        : base(_owner, _stateMachine, _animationBoolName)
    {
        threatRadius = owner.StateInfo.threatRadius;
    }

    public override void Enter()
    {
        base.Enter();

        targetShipTrm = owner.targetShip.transform;
        ownerTrm = owner.transform;
    }

    public override void Update()
    {
        base.Update();

        owner.Movement.SetMoveDir((targetShipTrm.position - ownerTrm.position).normalized);
        HandleThreatState();
    }

    private void HandleThreatState()
    {
        float distance = Vector3.Distance(ownerTrm.position, targetShipTrm.position);

        if(distance <= threatRadius)
        {
            owner.stateMachine.ChangeState(MegalodonStateType.Threat);
        }
    }
}
