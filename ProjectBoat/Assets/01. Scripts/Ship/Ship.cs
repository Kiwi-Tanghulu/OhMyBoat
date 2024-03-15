using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private ShipInputSO inputSO;

    [Space]
    [SerializeField] private Key key;
    [SerializeField] private Anchor anchor;
    [SerializeField] private Sail sail;

    [Space]
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float currentMoveSpeed;
    [SerializeField] private float moveAcceleration;

    [Space]
    [SerializeField] private CinemachineVirtualCamera shipCam;

    private bool canMove;

    private void Start()
    {
        InputManager.ChangeInputMap(InputMapType.Play);

        inputSO.OnEscapeEvetnt += ShipInputSO_OnEscapeEvent;
        anchor.OnActiveChange += Anchor_OnActiveChange;
        key.OnInteracted += Key_OnInteracted;
    }

    private void Update()
    {
        Rotate();

        if (canMove)
        {
            Accel();
            Move();
        }
        else
        {
            Stop();
        }
    }

    private void OnDestroy()
    {
        inputSO.OnEscapeEvetnt -= ShipInputSO_OnEscapeEvent;
        anchor.OnActiveChange -= Anchor_OnActiveChange;
        key.OnInteracted -= Key_OnInteracted;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.SetParent(null);
    }

    private void Move()
    {
        transform.position += (transform.forward * currentMoveSpeed + sail.CurrentWindForce) * Time.deltaTime;
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
        transform.Rotate(new Vector3(0f, key.CurrentRotation * Time.deltaTime, 0f));
    }

    private void ControlShip(bool startControl)
    {
        if(startControl)
        {
            shipCam.Priority = 100;
            InputManager.ChangeInputMap(InputMapType.Ship);
        }
        else
        {
            shipCam.Priority = 0;
            InputManager.ChangeInputMap(InputMapType.Play);
        }

        Debug.Log($"Ship Control : {startControl}");
    }

    private void Anchor_OnActiveChange(bool active)
    {
        canMove = !active; 
    }

    private void Key_OnInteracted()
    {
        ControlShip(true);
    }

    private void ShipInputSO_OnEscapeEvent()
    {
        ControlShip(false);
    }
}