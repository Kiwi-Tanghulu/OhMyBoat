using UnityEngine;

public interface IHolder
{
    public Transform HoldingParent { get; }
    public IGrabbable HoldingObject { get; }

    public bool IsEmpty { get; }

    /// <summary>
    /// release the holding object
    /// </summary>
    public void Release();
}
