using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        owner.playerMovement.SetVerticalVelocity(owner.playerMovement.JumpPower);
    }
    public override void Update()
    {
        base.Update();

        owner.playerMovement.Gravity();

        Vector3 moveVector = owner.transform.rotation * ((owner.playerMovement.MoveDir * owner.playerMovement.MoveSpeed));

        owner.playerMovement.Move(new Vector3(moveVector.x,0,moveVector.z));

        if (triggerCalled)
        {
            if (owner.playerMovement.IsGround()) 
            {
                owner.stateMachine.ChangeState(PlayerStateEnum.Idle);
            }
            else
            {
                owner.stateMachine.ChangeState(PlayerStateEnum.Fall);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
        owner.playerMovement.SetVerticalVelocity(0);
    }
}
