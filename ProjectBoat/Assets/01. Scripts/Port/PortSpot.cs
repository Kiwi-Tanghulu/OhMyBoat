using UnityEngine;

public class PortSpot : MonoBehaviour, IInteractable
{
    [SerializeField] Port port = null;

    public bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        if(actived == false)
            return false;

        port.Initialize();
        return true;
    }
}
