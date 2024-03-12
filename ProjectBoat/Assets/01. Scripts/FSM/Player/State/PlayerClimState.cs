using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimState : PlayerState
{
    public PlayerClimState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }
}
