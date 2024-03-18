using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpDownState : PlayerState
{
    public PlayerJumpDownState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        playerMovement.Move();

        if (triggerCalled)
        {
            stateMachine.ChangeState(PlayerStateEnum.Move);
        }
        //animator.SetLayerWeight(1, animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
