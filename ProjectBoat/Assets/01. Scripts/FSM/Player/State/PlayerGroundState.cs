using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        owner.playerMovement.Input.OnJumpEvent += HandleJumpEvent;
    }

    public override void Update()
    {
        base.Update();
        if (!owner.playerMovement.IsGround())
        {
            stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }

    public override void Exit()
    {
        owner.playerMovement.Input.OnJumpEvent -= HandleJumpEvent;
        base.Exit();
    }

    protected void HandleJumpEvent()
    {
        if (owner.playerMovement.IsGround())
        {
            stateMachine.ChangeState(PlayerStateEnum.Jump);
        }
    }
}
