using System;
using UnityEngine;

public class Stuff : MonoBehaviour, IGrabbable
{
	[SerializeField] StuffSO stuffData;
    public StuffSO StuffData => stuffData;

    private Rigidbody stuffRigidbody = null;

    private IHolder currentHolder = null;
    public IHolder CurrentHolder => currentHolder;

    public GameObject GrabObject => gameObject;

    public event Action<bool> OnGrabbedEvent = null;

    private void Awake()
    {
        stuffRigidbody = GetComponent<Rigidbody>();
    }

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

        ReleaseRigidbody();

        return true;
    }

    public void Release()
    {
        currentHolder = null;
        transform.SetParent(null);
        transform.localRotation = Quaternion.Euler(0f, transform.localEulerAngles.y, 0f);
        OnGrabbedEvent?.Invoke(false);

        stuffRigidbody.useGravity = true;
        stuffRigidbody.constraints = RigidbodyConstraints.None;
    }

    private void ReleaseRigidbody()
    {
        stuffRigidbody.useGravity = false;
        stuffRigidbody.angularVelocity = Vector3.zero;
        stuffRigidbody.velocity = Vector3.zero;
        stuffRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
