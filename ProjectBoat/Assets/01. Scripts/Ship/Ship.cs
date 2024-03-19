using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public static Ship Instance { get; private set; }

    [SerializeField] private ShipInputSO inputSO;

    [Space]
    [SerializeField] private ShipKey key;
    [SerializeField] private ShipAnchor anchor;
    [SerializeField] private ShipSail sail;
    public ShipKey Key => key;
    public ShipAnchor Anchor => anchor;
    public ShipSail Sail => sail;

    [Space]
    [SerializeField] private float maxMoveSpeed;
    [SerializeField] private float currentMoveSpeed;
    [SerializeField] private float moveAcceleration;

    private bool canMove;

    private Player player;

    public event Action<Island> OnSettlemented;
    public event Action<bool> OnShipControlChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InputManager.ChangeInputMap(InputMapType.Play);
        player = Player.Instance;

        anchor.OnActiveChange += Anchor_OnActiveChange;
        key.OnInteracted += Key_OnInteracted;

        ControlShip(true);
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
        anchor.OnActiveChange -= Anchor_OnActiveChange;
        key.OnInteracted -= Key_OnInteracted;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<SettlementPoint>(out SettlementPoint point))
        {
            Settlement(point.SettlementIsland);
        }
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
        transform.Rotate(new Vector3(0f, key.CurrentRotateValue * Time.deltaTime, 0f));
    }

    private void ControlShip(bool isControl)
    {
        if(isControl)
        {
            InputManager.ChangeInputMap(InputMapType.Ship);
        }
        else
        {
            InputManager.ChangeInputMap(InputMapType.Play);
        }

        OnShipControlChanged?.Invoke(isControl);
    }

    public void Settlement(Island island)
    {
        InputManager.ChangeInputMap(InputMapType.Play);
        anchor.SetActive(true, true);
        island.SetSettlementShip(this);
        transform.position = island.SettlementPoint.position;
        transform.rotation = island.SettlementPoint.rotation;
        OnSettlemented?.Invoke(island);
    }

    private void Anchor_OnActiveChange(bool active)
    {
        canMove = !active; 
    }

    private void Key_OnInteracted()
    {
        ControlShip(true);
    }
}