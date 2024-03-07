using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();

        Vector3 moveVector = owner.transform.rotation * ((owner.MoveDir * owner.MoveSpeed) * Time.deltaTime);

        owner.Move(new Vector3(moveVector.x,0,moveVector.z));

        if(owner.MoveDir.sqrMagnitude < 0.01f)
        {
            stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
