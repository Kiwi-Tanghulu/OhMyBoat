using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputSO input;

    [SerializeField] private float gravityScale;
    private float verticalVelocity;

    [SerializeField] private float moveSpeed;
    private Vector3 moveDir;

    private CharacterController cc;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Start()
    {
        input.OnMoveEvent += SetMoveDirection;
    }

    private void OnDestroy()
    {
        input.OnMoveEvent -= SetMoveDirection;
    }

    private void Update()
    {
        Gravity();
        Move();
    }

    private void Gravity()
    {
        if(!cc.isGrounded)
        {
            verticalVelocity += gravityScale * Time.deltaTime;
        }
        else
        {
            verticalVelocity = gravityScale * 0.3f * Time.deltaTime;
        }
    }

    public void SetMoveDirection(Vector2 value)
    {
        moveDir = new Vector3(value.x, 0f, value.y);
    }

    private void Move()
    {
        Vector3 moveVector = transform.rotation * ((moveDir * moveSpeed + verticalVelocity * Vector3.up) * Time.deltaTime);

        cc.Move(moveVector);
    }
}
