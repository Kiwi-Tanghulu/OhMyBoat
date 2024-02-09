using UnityEngine;

public class EquipmentVisual : MonoBehaviour, IFocusable
{
    private Equipment equipment = null;
    private Transform focusedVisual = null;
    private Collider visualCollider = null;

    public GameObject CurrentObject => equipment.gameObject;

    private void Awake()
    {
        equipment = transform.parent.GetComponent<Equipment>();
        focusedVisual = transform.Find("FocusedVisual");
        visualCollider = GetComponent<Collider>();

        equipment.OnGrabbedEvent += HandleGrabbed;
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
