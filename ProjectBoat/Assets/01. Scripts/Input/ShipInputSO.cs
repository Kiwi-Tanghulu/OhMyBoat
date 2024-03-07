using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputSO/ShipInputSO")]
public class ShipInputSO : InputSO, IShipActions
{
    public Action<Vector2> OnMoveEvent;
    public Action OnFEvent;
     
    protected override void OnEnable()
    {
        base.OnEnable();

        ShipActions ship = InputManager.controls.Ship;
        ship.SetCallbacks(this);
        InputManager.RegistInputMap(this, ship.Get());
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnF(InputAction.CallbackContext context)
    {
        if (context.started)
            OnFEvent?.Invoke();
    }
}
