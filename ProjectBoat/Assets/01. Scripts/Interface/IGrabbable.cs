using UnityEngine;

public interface IGrabbable
{
    public IHolder CurrentHolder { get; }

	public bool Grab(IHolder holder, Vector3 point = default);
    public void Release();
}
