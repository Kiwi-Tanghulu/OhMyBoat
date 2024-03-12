using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayInputSO input;
    public PlayInputSO Input => input;

    [SerializeField] private float moveSpeed;
    public float MoveSpeed => moveSpeed;
    private float currentSpeed;

    [SerializeField] private float jumpPower;
    public float JumpPower => jumpPower;

    [SerializeField] private float gravityScale;
    public float GravityScale => gravityScale;
    private float verticalVelocity;
    public Vector3 MoveDir { get; private set; }
    public bool IsRun { get; private set; }

    [SerializeField] private LayerMask groundLayer;

    private CharacterController characterController;

    //Test
    private PlayerFSM playerFSM;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        //Test
        playerFSM = GetComponent<PlayerFSM>();
    }
    private void Start()
    {
        input.OnMoveEvent += SetMoveDirection;
        input.OnRunEvent += SetRun;

        IsRun = false;
    }
    private void OnDestroy()
    {
        input.OnMoveEvent -= SetMoveDirection;
        input.OnRunEvent -= SetRun;
    }

    public void Gravity()
    {
        if (!IsGround())
        {
            verticalVelocity -= gravityScale * Time.deltaTime;
        }
    }
    private void SetRun()
    {
        IsRun = !IsRun;
        //Test
        playerFSM.TestRunAnimation(IsRun);
    }
    public void SetVerticalVelocity(float value)
    {
        verticalVelocity = value;
    }
    public void Move(Vector3 moveVector)
    {
        characterController.Move((moveVector + verticalVelocity * Vector3.up) * Time.deltaTime);
    }
    public void SetMoveDirection(Vector2 value)
    {
        MoveDir = new Vector3(value.x, 0f, value.y);
    }
    public bool IsGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.2f, groundLayer);
    }
}
