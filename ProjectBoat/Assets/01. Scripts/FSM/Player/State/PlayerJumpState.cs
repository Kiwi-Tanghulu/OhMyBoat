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
        playerMovement.SetVerticalVelocity(playerMovement.JumpPower);
    }
    public override void Update()
    {
        base.Update();

        playerMovement.Gravity();

        playerMovement.Move();

        if (triggerCalled)
        {
            owner.stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }

    public override void Exit()
    {
        base.Exit();
        playerMovement.SetVerticalVelocity(0);
    }
}
