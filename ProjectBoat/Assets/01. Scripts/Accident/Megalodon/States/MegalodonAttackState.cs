using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonAttackState : MegalodonState
{
    private float attackDistance;
    private bool attacked;

    public MegalodonAttackState(MegalodonFSM _owner, StateMachine<MegalodonFSM, MegalodonStateType> _stateMachine, string _animationBoolName) 
        : base(_owner, _stateMachine, _animationBoolName)
    {
        attackDistance = owner.StateInfo.attackDistance;    }

    public override void Enter()
    {
        base.Enter();

        attacked = false;
    }

    public override void Update()
    {
        base.Update();

        Vector3 dir = (targetShipTrm.position - ownerTrm.position).normalized;
        owner.Movement.SetMoveDir(dir);

        if(Vector3.Distance(ownerTrm.position, targetShipTrm.position) < attackDistance)
        {
            Debug.Log("megalodon attack");
            attacked = true;

            HandleChaseState();
        }
    }

    private void HandleChaseState()
    {
        if(attacked)
        {
            owner.stateMachine.ChangeState(MegalodonStateType.Chase);
        }
    }
}
