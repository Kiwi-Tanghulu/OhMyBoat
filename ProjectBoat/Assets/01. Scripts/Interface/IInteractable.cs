using UnityEngine;

public interface IInteractable
{
    public bool Interact(GameObject performer, bool actived, Vector3 point = default);
}
