using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputSO/UIInputSO")]
public class UIInputSO : InputSO, IUIActions
{
    public Action OnEscapeEvent = null;

    private void OnEnable()
    {
        UIActions play = InputManager.controls.UI;
        play.SetCallbacks(this);
        InputManager.RegistInputMap(this, play.Get());
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if(context.started)
            OnEscapeEvent?.Invoke();
    }
}
