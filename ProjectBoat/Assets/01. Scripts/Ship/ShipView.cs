using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipView : MonoBehaviour
{
    private Ship ship;
    private CinemachineVirtualCamera cam;
    //private Vector3 originRotation;

    private void Start()
    {
        ship = transform.parent.GetComponent<Ship>();
        cam = GetComponent<CinemachineVirtualCamera>();

        ship.OnShipControlChanged += Ship_OnShipControlChanged;

        //originRotation = transform.eulerAngles;
    }

    private void Ship_OnShipControlChanged(bool isControl)
    {
        cam.Priority = isControl ? 100 : 0;   
    }

    private void Update()
    {
        //shipCam.transform.rotation = Quaternion.Euler(originRotation.x, ship.Key.CurrentRotation, 0f);
    }
}
