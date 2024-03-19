using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardingPoint : MonoBehaviour
{
    private void Start()
    {
        Player.Instance.OnBoarding += Player_OnBoarding;
        Ship.Instance.OnSettlemented += Ship_OnSettlemented;

        gameObject.SetActive(false);
    }

    private void Ship_OnSettlemented(Island island)
    {
        gameObject.SetActive(true);
    }

    private void Player_OnBoarding()
    {
        gameObject.SetActive(false);
    }
}
