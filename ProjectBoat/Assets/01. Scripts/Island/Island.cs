using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    [SerializeField] private Transform landingPoint;
    [SerializeField] private Transform boardingPoint;
    [SerializeField] private Transform settlementTrm;
    private Ship settlementShip;

    public Transform LandingPoint => landingPoint;
    public Transform BoardingPoint => boardingPoint;
    public Transform SettlementTrm => settlementTrm;
    public Ship SettlementShip => settlementShip;

    private void Start()
    {
        Player.Instance.OnBoarding += Player_OnBoarding;
    }

    public void SetSettlementShip(Ship ship)
    {
        settlementShip = ship;
    }

    private void Player_OnBoarding()
    {
        settlementShip = null;
    }
}
