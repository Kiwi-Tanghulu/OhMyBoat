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

        owner.SetVerticalVelocity(owner.JumpPower);

        Debug.Log("점프진입");
    }
    public override void Update()
    {
        base.Update();

        owner.Gravity();

        Vector3 moveVector = owner.transform.rotation * ((owner.MoveDir * owner.MoveSpeed));

        owner.Move(new Vector3(moveVector.x,0,moveVector.z));

        if (triggerCalled)
        {
            Debug.Log("점프끝");
            if (owner.IsGround()) 
            {
                owner.stateMachine.ChangeState(PlayerStateEnum.Idle);
                Debug.Log("1");
            }
            else
            {
                owner.stateMachine.ChangeState(PlayerStateEnum.Fall);
                Debug.Log("2");
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
        owner.SetVerticalVelocity(0);
    }
}
