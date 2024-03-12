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

        playerMovement.Move();

        playerMovement.Gravity();

        if (playerMovement.IsGround())
        {
            owner.stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
        playerMovement.SetVerticalVelocity(0);
    }
}
