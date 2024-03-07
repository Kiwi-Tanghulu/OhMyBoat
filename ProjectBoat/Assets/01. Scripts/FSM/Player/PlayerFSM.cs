using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerFSM : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundChecklength;
    [SerializeField] private PlayInputSO input;
    public PlayInputSO Input => input;

    [SerializeField] private float gravityScale;
    public float GravityScale => gravityScale;

    [SerializeField] private float moveSpeed;
    public float MoveSpeed => moveSpeed;

    [SerializeField] private float jumpPower;
    public float JumpPower => jumpPower;


    public StateMachine<PlayerFSM, PlayerStateEnum> stateMachine;
    public Animator AnimatorCompo { get; private set; }
    public Vector3 MoveDir { get; private set; }


    private CharacterController characterController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
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
        input.OnMoveEvent += SetMoveDirection;

        stateMachine.Initialize(PlayerStateEnum.Idle, this);
    }

    private void OnDestroy()
    {
        input.OnMoveEvent -= SetMoveDirection;
    }
    void Update()
    {
        stateMachine.CurrentState.Update();
    }

    public void SetMoveDirection(Vector2 value)
    {
        MoveDir = new Vector3(value.x, 0f, value.y);
    }
    public void Move(Vector3 moveVector)
    {
        characterController.Move(moveVector);
    }
    public void AnimationEndTrigger()
    {
        stateMachine.CurrentState.AnimationFinishTrigger();
    }

    public bool IsGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.1f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position - new Vector3(0, 0.05f, 0));
    }
}
