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

        Vector3 moveVector = owner.transform.rotation * ((owner.MoveDir * owner.MoveSpeed + owner.GravityScale * Vector3.down) * Time.deltaTime);
        owner.Move(moveVector);

        if (owner.IsGround())
        {
            owner.stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }
}
