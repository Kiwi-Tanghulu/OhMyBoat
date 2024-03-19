using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementPoint : MonoBehaviour
{
    [SerializeField] private Island settlementIsland;

    public Island SettlementIsland => settlementIsland;

    private void Start()
    {
        Player.Instance.OnBoarding += Player_OnBoarding;
        Ship.Instance.OnSettlemented += Ship_OnSettlemented;
    }

    private void Ship_OnSettlemented(Island island)
    {
        gameObject.SetActive(false);
    }

    private void Player_OnBoarding()
    {
        gameObject.SetActive(true);
    }
}
