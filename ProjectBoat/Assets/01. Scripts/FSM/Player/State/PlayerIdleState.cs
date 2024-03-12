using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Update()
    {
        base.Update();

        if (owner.playerMovement.MoveDir.sqrMagnitude > 0.01f)
        {
            stateMachine.ChangeState(PlayerStateEnum.Move);
        }
    }
}
