using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipView : MonoBehaviour
{
    [SerializeField] private ShipInputSO inputSO;
    
    [Space]
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Transform armTrm;

    [Space]
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Vector2 rotationClampValue;
    [SerializeField] private bool inverseX;
    [SerializeField] private bool inverseY;
    private float xRotate;
    private float yRotate;


    private void Start()
    {
        Ship.Instance.OnShipControlChanged += Ship_OnShipControlChanged;
        Ship.Instance.OnSettlemented += Ship_OnSettlemented;
        Player.Instance.OnBoarding += Player_OnBoarding;

        inputSO.OnMouseDeltaEvent += InputSO_OnMouseDeltaEvent;
    }

    private void Player_OnBoarding()
    {
        cam.Priority = 100;
    }

    private void Ship_OnSettlemented(Island island)
    {
        cam.Priority = 0;
    }

    private void Ship_OnShipControlChanged(bool isControl)
    {
        cam.Priority = isControl ? 100 : 0;   
    }

    private void InputSO_OnMouseDeltaEvent(Vector2 delta)
    {
        float xDelta = delta.y * rotateSpeed;
        if(inverseX)
            xDelta *= -1;
        xRotate += xDelta;
        xRotate = Mathf.Clamp(xRotate, rotationClampValue.x, rotationClampValue.y);

        float yDelta = delta.x * rotateSpeed;   
        if(inverseY)
            yDelta *= -1;
        yRotate += yDelta;

        armTrm.localRotation = Quaternion.Euler(xRotate, yRotate, 0f);
    }
}
