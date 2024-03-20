using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCanvas : MonoBehaviour
{
    private void Start()
    {
        Player.Instance.OnBoarding += Player_OnBoarding;
        Ship.Instance.OnSettlemented += Ship_OnSettlemented;
    }

    private void Player_OnBoarding()
    {
        gameObject.SetActive(true);
    }

    private void Ship_OnSettlemented(Island obj)
    {
        gameObject.SetActive(false);
    }
}
