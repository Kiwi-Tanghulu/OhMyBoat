using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
	[SerializeField] PlayInputSO input;

    private PlayerFocuser focuser = null;

    private PlayerHand hand = null;
    public PlayerHand Hand => hand;

    private PlayerMovement movement = null;
    public PlayerMovement Movement => movement;

    private IFocusable lastFocusedTarget = null;
    private IInteractable currentTarget = null;

    private void Awake()
    {
        input.OnInteractEvent += HandleInteract;
        focuser = GetComponent<PlayerFocuser>();
        hand = GetComponent<PlayerHand>();
        movement = GetComponent<PlayerMovement>();
    }

    private void OnDestroy()
    {
        input.OnInteractEvent -= HandleInteract;
    }

    private void HandleInteract(bool actived)
    {
        if(focuser.IsEmpty)
            return;

        if(lastFocusedTarget != focuser.FocusedObject)
            currentTarget = focuser.FocusedObject.CurrentObject.GetComponent<IInteractable>();

        currentTarget?.Interact(this, actived, focuser.FocusedPoint);
    }
}
