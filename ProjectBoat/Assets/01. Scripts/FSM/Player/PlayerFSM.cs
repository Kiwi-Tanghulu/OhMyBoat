using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerFSM : MonoBehaviour
{
    public StateMachine<PlayerFSM, PlayerStateEnum> stateMachine;
    public Animator AnimatorCompo { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }
    private void Awake()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        AnimatorCompo = transform.Find("Visual").GetComponent<Animator>();

        stateMachine = new StateMachine<PlayerFSM, PlayerStateEnum>();

        foreach (PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = stateEnum.ToString();
            try
            {
                Type type = Type.GetType($"Player{typeName}State");
                PlayerState stateInstance = Activator.CreateInstance(type, this, stateMachine, typeName) as PlayerState;

                stateMachine.AddState(stateEnum, stateInstance);
            }
            catch (Exception e)
            {
                Debug.Log($"{typeName} 클래스 인스턴스를 생성할 수 없습니다. {e.Message}");
            }
        }

    }

    private void Start()
    {
        stateMachine.Initialize(PlayerStateEnum.Idle, this);
    }
    void Update()
    {
        stateMachine.CurrentState.Update();
    }

    public void AnimationEndTrigger()
    {
        stateMachine.CurrentState.AnimationFinishTrigger();
    }


}
