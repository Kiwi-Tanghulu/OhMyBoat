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
    [SerializeField] private float climSpeed;
    public float ClimSpeed => climbSpeed;

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

    #region LadderVariable
    public Vector3 LadderUpPos { get; private set; }
    public Vector3 LadderDownPos { get; private set; }
    public Vector3 UpArrivePos { get; private set; }
    public Vector3 DownArrivePos { get; private set; }
    #endregion

    [SerializeField] private LayerMask groundLayer;

    private PlayerFSM playerFSM;
    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerFSM = GetComponent<PlayerFSM>();
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
            verticalVelocity -= gravityScale * Time.deltaTime;
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
    public void Teleport(Vector3 teleportPos)
    {
        characterController.Move(teleportPos);
    }
    #region Clim
    public void Climing()
    {
        characterController.Move(climbSpeed * MoveDir.z * Vector3.up * Time.deltaTime);
    }
    public void SetClimingPos(Vector3 ladderUp, Vector3 ladderDown, Vector3 upArrive, Vector3 downArrive)
    {
        LadderUpPos = ladderUp;
        LadderDownPos = ladderDown;
        UpArrivePos = upArrive;
        DownArrivePos = downArrive;
        playerFSM.stateMachine.ChangeState(PlayerStateEnum.Clim);
    }
    #endregion
    public bool IsGround()
    {
        return Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, 0.12f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + Vector3.up * 0.1f, transform.position + Vector3.up * 0.1f  + Vector3.down * 0.1f);
    }
}
