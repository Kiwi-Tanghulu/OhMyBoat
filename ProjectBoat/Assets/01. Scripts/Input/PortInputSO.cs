using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputSO/PortInputSO")]
public class PortInputSO : InputSO, IPortActions
{
    public Action<bool> OnLeftClickedEvent = null;
    public Action<bool> OnRightClickedEvent = null;
    public Vector2 MouseDelta { get; private set; } = Vector2.zero;

    protected override void OnEnable()
    {
        base.OnEnable();
        PortActions play = InputManager.controls.Port;
        play.SetCallbacks(this);
        InputManager.RegistInputMap(this, play.Get());
    }

    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        MouseDelta = context.ReadValue<Vector2>();
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnLeftClickedEvent?.Invoke(true);
        else if(context.canceled)
            OnLeftClickedEvent?.Invoke(false);
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnRightClickedEvent?.Invoke(true);
        else if (context.canceled)
            OnRightClickedEvent?.Invoke(false);
    }
}
