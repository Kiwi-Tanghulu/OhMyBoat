using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    
    public override void Update()
    {
        base.Update();

        owner.Gravity();

        Vector3 moveVector = owner.transform.rotation * ((owner.MoveDir * owner.MoveSpeed));
        owner.Move(new Vector3(moveVector.x,0,moveVector.z));

        if (owner.IsGround())
        {
            owner.stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
        owner.SetVerticalVelocity(0);
    }
}
