using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Key key;
    [SerializeField] private Anchor anchor;

    [Space]
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float currentMoveSpeed;
    [SerializeField] private float moveAcceleration;

    private bool canMove;

    private void Awake()
    {
        InputManager.ChangeInputMap(InputMapType.Ship);
    }

    private void Start()
    {
        anchor.OnActiveChange += Anchor_OnActiveChange;
    }

    private void Update()
    {
        Rotate();

        if (canMove)
            Accel();
        else
            Stop();

        Move();
    }

    private void OnDestroy()
    {
        anchor.OnActiveChange -= Anchor_OnActiveChange;
    }

    private void Move()
    {
        transform.position += transform.forward * currentMoveSpeed * Time.deltaTime;
    }

    private void Accel()
    {
        currentMoveSpeed += moveAcceleration * Time.deltaTime;
        currentMoveSpeed = Mathf.Clamp(currentMoveSpeed, 0f, maxMoveSpeed);
    }

    private void Stop()
    {
        currentMoveSpeed = 0f;
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0f, key.CurrentRotate * Time.deltaTime, 0f));
    }

    private void Anchor_OnActiveChange(bool active)
    {
        canMove = !active;
    }
}