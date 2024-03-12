using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State<PlayerFSM, PlayerStateEnum>
{
    protected Animator animator;
    public PlayerState(PlayerFSM _owner, StateMachine<PlayerFSM, PlayerStateEnum> _stateMachine, string _animationBoolName) : base(_owner, _stateMachine, _animationBoolName)
    {
        animator = owner.AnimatorCompo;
    }

    public override void Enter()
    {
        base.Enter();
        animator.SetBool(animBoolHash, true);
    }

    public override void Exit()
    {
        base.Exit();
        animator.SetBool(animBoolHash, false);
    }

    public override void Update()
    {
        base.Update();
    }
}