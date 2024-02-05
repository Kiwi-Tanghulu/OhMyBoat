using System;
using UnityEngine;

public class Stuff : MonoBehaviour, IGrabbable
{
	[SerializeField] StuffSO stuffData;
    public StuffSO StuffData => stuffData;

    private IHolder currentHolder = null;
    public IHolder CurrentHolder => currentHolder;

    public event Action<bool> OnGrabbedEvent = null;

    public bool Grab(IHolder holder, Vector3 point = default)
    {
        if(holder.IsEmpty == false)
            return false;

        if(currentHolder != null)
            return false;

        currentHolder = holder;
        transform.SetParent(currentHolder.HoldingParent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        OnGrabbedEvent?.Invoke(true);

        return true;
    }

    public void Release()
    {
        currentHolder = null;
        transform.SetParent(null);
        transform.localRotation = Quaternion.Euler(0f, transform.localEulerAngles.y, 0f);
        OnGrabbedEvent?.Invoke(false);
    }
}
