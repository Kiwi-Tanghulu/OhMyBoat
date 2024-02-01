using UnityEngine;

public interface IInteractable
{
    public bool Interact(GameObject performer = null, Vector3 point = default);
}
