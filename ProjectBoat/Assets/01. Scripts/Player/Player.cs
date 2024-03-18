using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public PlayerMovement movement { get; private set; }

    public Action OnBoarding;

    private void Awake()
    {
        Instance = this;

        movement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        Ship.Instance.OnSettlemented += Ship_OnSettlemented;
    }

    private void OnDestroy()
    {
        OnBoarding = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoardingPoint"))
        {
            Boarding();
        }
    }

    public void Boarding()
    {
        InputManager.ChangeInputMap(InputMapType.Ship);
        gameObject.SetActive(false);
        OnBoarding?.Invoke();
    }

    private void Ship_OnSettlemented(Island island)
    {
        movement.Teleport(island.LandingPoint.position);
        gameObject.SetActive(true);
    }

}
