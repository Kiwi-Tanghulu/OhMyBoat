using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputSO/MiniGameInputSO")]
public class MiniGameInputSO : InputSO, IMiniGameActions
{
    public event Action OnSpaceEvent;
    public event Action OnAEvent;
    public event Action OnDEvent;
    protected override void OnEnable()
    {
        base.OnEnable();

        MiniGameActions miniGame = InputManager.controls.MiniGame;
        miniGame.SetCallbacks(this);
        InputManager.RegistInputMap(this, miniGame.Get());
    }

    public void OnSpace(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnSpaceEvent?.Invoke();
        }
    }

    public void OnA(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnAEvent?.Invoke();
        }
    }

    public void OnD(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnDEvent?.Invoke();
        }
    }
}
