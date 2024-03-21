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
        playerMovement.IsJump = true;
        playerMovement.Rigid.AddForce(Vector3.up * playerMovement.JumpPower, ForceMode.Impulse);
    }
    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            owner.stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }

    public override void Exit()
    {
        base.Exit();
        playerMovement.IsJump = false;
    }
}
