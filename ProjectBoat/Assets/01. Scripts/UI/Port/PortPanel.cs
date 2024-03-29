using System;
using UnityEngine;
using UnityEngine.Events;

public class PortPanel : MonoBehaviour
{
    [SerializeField] PortSO portData = null;

	private ShipInfoPanel infoPanel = null;
    private ShipPurchasePanel purchasePanel = null;
    private ShipPurchasePanel upgradePanel = null;

    private ShipSO focusedShipData = null;

    public event Action<ShipSO> OnPurchaseEvent = null;
    public event Action<ShipSO> OnUpgradeEvent = null;

    private void Awake()
    {
        infoPanel = transform.Find("InfoPanel").GetComponent<ShipInfoPanel>();
        purchasePanel = transform.Find("PurchasePanel").GetComponent<ShipPurchasePanel>();
        upgradePanel = transform.Find("UpgradePanel").GetComponent<ShipPurchasePanel>();

        purchasePanel.OnPurchaseEvent += () => OnPurchaseEvent?.Invoke(focusedShipData);
        upgradePanel.OnPurchaseEvent += () => OnUpgradeEvent?.Invoke(focusedShipData);

        portData.OnCurrentShipChangedEvent += HandleShipChanged;
    }

    private void Start()
    {
        Display(false);
    }

    private void OnDestroy()
    {
        portData.OnCurrentShipChangedEvent -= HandleShipChanged;
    }

    public void Initialize(ShipSO shipData)
    {
        focusedShipData = shipData;
        infoPanel.Initialize(focusedShipData);

        SetPurchasePanel();
        focusedShipData.OnLevelChanged += HandleLevelChanged;
    }

    public void Release()
    {
        focusedShipData.OnLevelChanged -= HandleLevelChanged;
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    private void HandleLevelChanged()
    {
        SetPurchasePanel();
    }

    private void SetPurchasePanel()
    {
        purchasePanel.Display(!focusedShipData.IsPurchased);
        upgradePanel.Display(focusedShipData.IsPurchased);

        int price = focusedShipData.Level > DEFINE.ShipMaxLevel ? -1 : focusedShipData.GetPrice();
        purchasePanel.SetPrice(price);
        upgradePanel.SetPrice(price);
    }

    private void HandleShipChanged()
    {
        Initialize(portData.CurrentShipData);
    }
}
