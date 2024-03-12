using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayInputSO input;
    public PlayInputSO Input => input;

    [SerializeField] private float speedMultiplier;

    [SerializeField] private float runSpeed;
    public float RunSpeed => runSpeed;
    [SerializeField] private float walkSpeed;
    public float WalkSpeed => walkSpeed;
    [SerializeField] private float swimSpeed;
    public float SwimSpeed => swimSpeed;

    private float currentMaxSpeed;
    public float CurrentMaxSpeed => currentMaxSpeed;
    private float currentSpeed;
    public float CurrentSpeed => currentSpeed;

    [SerializeField] private float climbSpeed;
    public float ClimbSpeed => climbSpeed;

    [SerializeField] private float jumpPower;
    public float JumpPower => jumpPower;

    [SerializeField] private float gravityScale;
    public float GravityScale => gravityScale;
    private float verticalVelocity;
    public Vector3 MoveDir { get; private set; }
    private Vector3 lastMoveDir;

    [SerializeField] private LayerMask groundLayer;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        input.OnMoveEvent += SetMoveDirection;
    }
    private void OnDestroy()
    {
        input.OnMoveEvent -= SetMoveDirection;
    }

    public void Gravity()
    {
        if (!IsGround())
        {
            verticalVelocity -= gravityScale * Time.deltaTime;
        }
    }
    public void SetCurrentMaxSpeed(float _currentMaxSpeed)
    {
        currentMaxSpeed = _currentMaxSpeed;
    }
    public void SpeedCalculate()
    {
        if (currentSpeed > currentMaxSpeed)
            currentSpeed += -speedMultiplier * Time.deltaTime;
        else
            currentSpeed += (MoveDir.sqrMagnitude > 0.1f ? speedMultiplier : -speedMultiplier) * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0f, runSpeed);
    }
    public void ResetSpeed()
    {
        currentSpeed = 0f;
    }
    public void SetVerticalVelocity(float value)
    {
        verticalVelocity = value;
    }
    public void Move()
    {
        characterController.Move((transform.rotation * lastMoveDir * currentSpeed + verticalVelocity * Vector3.up) * Time.deltaTime);
    }
    public void SetMoveDirection(Vector2 value)
    {
        MoveDir = new Vector3(value.x, 0f, value.y);
        if (value.sqrMagnitude > 0.1f)
            lastMoveDir = MoveDir;
    }
    public bool IsGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.2f, groundLayer);
    }
}
