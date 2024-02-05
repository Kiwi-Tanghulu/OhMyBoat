using UnityEngine;

public class StuffVisual : MonoBehaviour, IFocusable
{
    private Stuff stuff = null;
    private Transform focusedVisual = null; 
    private Collider visualCollider = null;

    public GameObject CurrentObject => stuff.gameObject;

    private void Awake()
    {
        stuff = transform.parent.GetComponent<Stuff>();
        focusedVisual = transform.Find("FocusedVisual");
        visualCollider = GetComponent<Collider>();

        stuff.OnGrabbedEvent += HandleGrabbed;
    }

    private void HandleGrabbed(bool grabbed)
    {
        visualCollider.enabled = !grabbed;
    }

    public void OnFocusBegin(Vector3 point)
    {
        focusedVisual.gameObject.SetActive(true);
    }

    public void OnFocusEnd()
    {
        focusedVisual.gameObject.SetActive(false);
    }
}
