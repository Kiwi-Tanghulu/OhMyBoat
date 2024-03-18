using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonThreatState : MegalodonState
{
    private float threatAngle;

    public MegalodonThreatState(MegalodonFSM _owner, StateMachine<MegalodonFSM, MegalodonStateType> _stateMachine, string _animationBoolName) 
        : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Vector3 shipToMegalodonDir = (owner.transform.position - owner.targetShip.transform.position).normalized;
        threatAngle = Mathf.Rad2Deg * Mathf.Atan2(shipToMegalodonDir.z, shipToMegalodonDir.x);
    }

    public override void Update()
    {
        base.Update();

        threatAngle = (threatAngle + Time.deltaTime * 5) % 360f;
        //Vector3 point = 
    }
}
