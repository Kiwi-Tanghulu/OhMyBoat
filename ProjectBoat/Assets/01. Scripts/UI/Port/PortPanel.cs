using UnityEngine;

public class PortPanel : MonoBehaviour
{
	private ShipStatPanel statPanel = null;

    public ShipSO a;

    private void Awake()
    {
        statPanel = transform.Find("StatPanel").GetComponent<ShipStatPanel>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            Initialize(a);
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
