using UnityEngine;

public class PortPanel : MonoBehaviour
{
	private ShipStatPanel statPanel = null;

    public ShipSO a;

    private void Awake()
    {
        statPanel = transform.Find("StatPanel").GetComponent<ShipStatPanel>();
        Initialize(a);
    }

    private void Start()
    {
        Display(false);
    }

    public void Initialize(ShipSO shipData)
    {
        statPanel.Initialize(shipData);
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }
}
