using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonMoveState : MegalodonState
{
    private float changeMoveDirTime;
    private float lastChangeMoveDirTime;

    private float detectRadius;
    private LayerMask shipLayer;

    public MegalodonMoveState(MegalodonFSM _owner, StateMachine<MegalodonFSM, MegalodonStateType> _stateMachine, string _animationBoolName) 
        : base(_owner, _stateMachine, _animationBoolName)
    {
        detectRadius = owner.StateInfo.detectRadius;
        shipLayer = owner.StateInfo.shipLayer;
    }

    public override void Enter()
    {
        base.Enter();
        lastChangeMoveDirTime = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if(lastChangeMoveDirTime < Time.time + changeMoveDirTime)
        {
            float x = UnityEngine.Random.Range(-1f, 1f);
            float y = UnityEngine.Random.Range(-1f, 1f);

            owner.Movement.SetMoveDir(new Vector2(x, y).normalized);
        }

        HandleChaseState();
    }

    private void HandleChaseState()
    {
        Collider[] cols = Physics.OverlapSphere(owner.transform.position, detectRadius, shipLayer);

        if(cols.Length > 0)
        {
            if(cols[0].TryGetComponent<Ship>(out Ship ship))
            {
                owner.SetTargetShip(ship);
                owner.stateMachine.ChangeState(MegalodonStateType.Chase);
            }
        }
    }
}
