using UnityEngine;

public class PortPanel : MonoBehaviour
{
	private ShipInfoPanel infoPanel = null;

    public ShipSO a;

    private void Awake()
    {
        infoPanel = transform.Find("InfoPanel").GetComponent<ShipInfoPanel>();
        Initialize(a);
    }

    private void Start()
    {
        Display(false);
    }

    public void Initialize(ShipSO shipData)
    {
        infoPanel.Initialize(shipData);
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }
}
