using UnityEngine;

public class Stuff : MonoBehaviour, IGrabbable
{
	[SerializeField] StuffSO stuffData;

    private IHolder currentHolder = null;
    public IHolder CurrentHolder => currentHolder;

    public bool Grab(IHolder holder, Vector3 point = default)
    {
        if(holder.IsEmpty == false)
            return false;

        if(currentHolder != null)
            return false;

        currentHolder = holder;
        transform.SetParent(currentHolder.HoldingParent);
        transform.localPosition = Vector3.zero;

        return true;
    }

    public void Release()
    {
        currentHolder = null;
        transform.SetParent(null);
    }
}
