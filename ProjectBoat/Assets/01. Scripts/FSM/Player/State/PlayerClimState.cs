using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimState : PlayerState
{
    private Vector3 ladderUpPos;
    private Vector3 ladderDownPos;
    private Vector3 upArrivePos;
    private Vector3 downArrivePos;
    public PlayerClimState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        playerMovement.Input.OnMoveEvent += HandleClimEvent;
        ladderUpPos = playerMovement.LadderUpPos;
        ladderDownPos = playerMovement.LadderDownPos;
        upArrivePos = playerMovement.UpArrivePos;
        downArrivePos = playerMovement.DownArrivePos;

        animator.SetFloat("ClimSpeed", 0f);
    }

    public override void Update()
    {
        base.Update();

        if(ladderUpPos.y < owner.transform.position.y)
        {
            playerMovement.Teleport(upArrivePos);
            stateMachine.ChangeState(PlayerStateEnum.Move);
        }
        
        if(ladderDownPos.y > owner.transform.position.y)
        {
            playerMovement.Teleport(downArrivePos);
            stateMachine.ChangeState(PlayerStateEnum.Move);
        }
    }

    private void HandleClimEvent(Vector2 moveDir)
    {
        if (Mathf.Abs(moveDir.y) < 0.1f)
        {
            animator.SetFloat("ClimSpeed", 0f);
        }
        else
        {
            animator.SetFloat("ClimSpeed", 1f);
        }
    }

    public override void Exit()
    {
        base.Exit();
        playerMovement.Input.OnMoveEvent -= HandleClimEvent;
    }
}
