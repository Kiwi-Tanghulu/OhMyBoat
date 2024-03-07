using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }


    public override void Update()
    {
        base.Update();



        Vector3 moveVector = owner.transform.rotation * ((owner.MoveDir * owner.MoveSpeed + owner.JumpPower * Vector3.up) * Time.deltaTime);

        owner.Move(moveVector);

        if (triggerCalled)
        {
            owner.stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }
}
