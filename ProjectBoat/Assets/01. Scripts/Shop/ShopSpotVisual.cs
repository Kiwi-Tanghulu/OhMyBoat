using UnityEngine;

public class ShopSpotVisual : MonoBehaviour, IFocusable
{
    private ShopSpot shopSpot = null;
    private Transform focusedVisual = null;
    private Collider visualCollider = null;

    public GameObject CurrentObject => shopSpot.gameObject;

    private void Awake()
    {
        shopSpot = transform.parent.GetComponent<ShopSpot>();
        focusedVisual = transform.Find("FocusedVisual");
        visualCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        shopSpot.OnFocusedEvent += HandleShopSpotFocused;
    }

    public void OnFocusBegin(Vector3 point)
    {
        focusedVisual.gameObject.SetActive(true);
    }

    public void OnFocusEnd()
    {
        focusedVisual.gameObject.SetActive(false);
    }
    
    private void HandleShopSpotFocused(bool focus)
    {
        visualCollider.enabled = !focus;
    }
}
