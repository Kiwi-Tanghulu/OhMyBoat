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

    private void OnEnable()
    {
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
}
