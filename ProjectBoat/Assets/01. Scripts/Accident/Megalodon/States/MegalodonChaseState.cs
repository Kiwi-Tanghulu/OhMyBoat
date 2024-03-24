using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonChaseState : MegalodonState
{
    

    private Vector3 moveDir;

    private float threatDistance;

    public MegalodonChaseState(MegalodonFSM _owner, StateMachine<MegalodonFSM, MegalodonStateType> _stateMachine, string _animationBoolName) 
        : base(_owner, _stateMachine, _animationBoolName)
    {
        threatDistance = owner.StateInfo.threatDistance;
    }

    public override void Update()
    {
        base.Update();

        moveDir = targetShipTrm.position - ownerTrm.position;
        moveDir.y = 0;
        moveDir.Normalize();

        owner.Movement.SetMoveDir(moveDir);
        HandleThreatState();
    }

    private void HandleThreatState()
    {
        float distance = Vector3.Distance(ownerTrm.position, targetShipTrm.position);

        if(distance <= threatDistance)
        {
            owner.stateMachine.ChangeState(MegalodonStateType.Threat);
        }
    }
}
