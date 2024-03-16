using UnityEngine;

public class PortSpotVisual : MonoBehaviour, IFocusable
{
	private PortSpot portSpot = null;
    private Transform focusedVisual = null;
    private Collider visualCollider = null;

    public GameObject CurrentObject => portSpot.gameObject;

    private void Awake()
    {
        portSpot = transform.parent.GetComponent<PortSpot>();
        focusedVisual = transform.Find("FocusedVisual");
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