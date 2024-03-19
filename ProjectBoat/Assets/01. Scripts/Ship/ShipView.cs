using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipView : MonoBehaviour
{
    private CinemachineVirtualCamera cam;

    private void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();

        Ship.Instance.OnShipControlChanged += Ship_OnShipControlChanged;
        Ship.Instance.OnSettlemented += Ship_OnSettlemented;
        Player.Instance.OnBoarding += Player_OnBoarding;
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
}
