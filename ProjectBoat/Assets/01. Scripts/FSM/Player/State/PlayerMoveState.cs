using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    private bool isRun;
    public PlayerMoveState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        playerMovement.Input.OnRunEvent += SetRun;
        isRun = false;
        playerMovement.SetCurrentMaxSpeed(playerMovement.WalkSpeed);
    }
    public override void Update()
    {
        base.Update();
        playerMovement.SpeedCalculate();

        //if(playerMovement.CurrentSpeed > playerMovement.WalkSpeed + 0.1f)
        //{
        //    animator.SetFloat("move_speed", 
        //        (playerMovement.CurrentSpeed - playerMovement.WalkSpeed) / (playerMovement.RunSpeed - playerMovement.WalkSpeed));
        //}
    }

    private void SetRun(bool value)
    {
        isRun = value;
        if (isRun)
            playerMovement.SetCurrentMaxSpeed(playerMovement.RunSpeed);
        else
        {
            playerMovement.SetCurrentMaxSpeed(playerMovement.WalkSpeed);
        }
    }

    public override void Exit()
    {
        playerMovement.Input.OnRunEvent -= SetRun;
        base.Exit();
    }

}
