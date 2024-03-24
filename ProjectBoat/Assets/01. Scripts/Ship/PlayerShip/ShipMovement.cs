using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private ShipInputSO inputSO;

    [Space]
    [SerializeField] private float moveSpeedAccelation;
    [SerializeField] private float maxMoveSpeed;
    private float moveSpeed;
    private float accelDir;
    private Vector3 moveVector;
    private Vector3 forward;

    [Space]
    [SerializeField] private float rotateSpeedAccelation;
    [SerializeField] private float maxRotateSpeed;
    private float rotateSpeed;
    private float rotateDir;

    private void Start()
    {
        inputSO.OnMoveEvent += SetAccelDir;
    }

    private void Update()
    {
        Rotate();
        Accel();
        Move();
    }

    private void SetAccelDir(Vector2 input)
    {
        accelDir = input.y == 0 ? 0f : Mathf.Sign(input.y);
        rotateDir = input.x == 0f ? 0f : Mathf.Sign(input.x);
    }

    private void Accel()
    {
        float moveDest = maxMoveSpeed * accelDir;
        float rotateDest = maxRotateSpeed * rotateDir;

        moveSpeed = Mathf.Lerp(moveSpeed, moveDest, Time.deltaTime * moveSpeedAccelation);
        rotateSpeed = Mathf.Lerp(rotateSpeed, rotateDest, Time.deltaTime * rotateSpeedAccelation);
    }

    private void Move()
    {
        
        transform.position += forward * moveSpeed * Time.deltaTime;
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0f, rotateSpeed * Time.deltaTime, 0f));

        forward = new Vector3(transform.forward.x, 0f, transform.forward.z);
    }
}