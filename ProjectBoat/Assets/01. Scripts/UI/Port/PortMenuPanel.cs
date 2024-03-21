using System;
using UnityEngine;
using UnityEngine.UI;

public class PortMenuPanel : MonoBehaviour
{
    [SerializeField] UIInputSO input = null;
    [SerializeField] PortSO portData = null;

    private ShipSO focusedShip = null;
    private Button selectButton = null;

    private void Awake()
    {
        selectButton = transform.Find("SelectButton").GetComponent<Button>();

        portData.OnCurrentShipChangedEvent += HandleShipChanged;
    }

    private void OnDestroy()
    {
        portData.OnCurrentShipChangedEvent -= HandleShipChanged;
    }

    private void HandleShipChanged()
    {
        if(focusedShip != null)
            focusedShip.OnLevelChanged -= HandleLevelChanged;
        focusedShip = portData.CurrentShipData;
        focusedShip.OnLevelChanged += HandleLevelChanged;

        selectButton.interactable = focusedShip.IsPurchased;
    }

    private void HandleLevelChanged()
    {
        selectButton.interactable = focusedShip.IsPurchased;
    }

    public void HandleSelectButton()
    {
        if(portData.CurrentShipData.IsPurchased == false)
            return;

        input.OnEscapeEvent?.Invoke();
    }

    public void HandleSwitch(int direction)
    {
        int current = portData.CurrentShipIndex;
        current = (current + direction + portData.Count) % portData.Count;
        portData.ChangeShip(current);
    }
}
