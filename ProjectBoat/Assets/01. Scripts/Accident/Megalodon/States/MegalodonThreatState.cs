using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MegalodonThreatState : MegalodonState
{
    private float threatDistance;

    private float stateTime;
    private float attackDelay;

    public MegalodonThreatState(MegalodonFSM _owner, StateMachine<MegalodonFSM, MegalodonStateType> _stateMachine, string _animationBoolName) 
        : base(_owner, _stateMachine, _animationBoolName)
    {
        threatDistance = owner.StateInfo.threatDistance;
        attackDelay = owner.StateInfo.attackDelay;
    }

    public override void Enter()
    {
        base.Enter();

        stateTime = 0f;
    }

    public override void Update()
    {
        base.Update();

        Threat();

        HandleAttackState();
    }

    private void Threat()
    {
        Vector3 targetPos = (ownerTrm.position - targetShipTrm.position).normalized * threatDistance + targetShipTrm.position;
        targetPos += Quaternion.Euler(0f, 90f, 0f) * targetPos.normalized;
        Vector3 dir = (targetPos - ownerTrm.position).normalized;
        dir.y = 0;
        owner.Movement.SetMoveDir(dir);
    }

    private void HandleAttackState()
    {
        stateTime += Time.deltaTime;

        if (stateTime >= attackDelay)
            owner.stateMachine.ChangeState(MegalodonStateType.Attack);
    }
}
