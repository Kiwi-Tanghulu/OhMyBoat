using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Controls;

[CreateAssetMenu(menuName = "SO/InputSO")]
public class InputSO : ScriptableObject, IPlayActions
{
    private Controls controls;

    public Action<Vector2> OnMoveEvent;
    public Action<Vector2> OnMouseDeltaEvent;
    public Action OnJumpEvent;
    public Action OnCollectEvent;
    public Action<bool> OnInteractEvent;

    private void OnEnable()
    {
        if(controls == null)
        {
            controls = new Controls();
        }

        controls.Play.SetCallbacks(this);
        controls.Play.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveDirection = context.ReadValue<Vector2>();

        OnMoveEvent?.Invoke(moveDirection);
    }

    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        Vector2 mouseDelta = context.ReadValue<Vector2>();

        OnMouseDeltaEvent?.Invoke(mouseDelta);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnJumpEvent?.Invoke();
        }
    }

    public void OnCollect(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnCollectEvent?.Invoke();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnInteractEvent?.Invoke(true);
        else if(context.canceled)
            OnInteractEvent?.Invoke(false);
    }
}
