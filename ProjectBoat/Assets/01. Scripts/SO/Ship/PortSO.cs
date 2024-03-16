using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Ship/PortData")]
public class PortSO : ScriptableObject
{
	[SerializeField] List<ShipSO> shipList = null;
    public int Count => shipList.Count;

    private int currentShipIndex = 0;
    public int CurrentShipIndex => currentShipIndex;
    public ShipSO CurrentShipData => shipList[currentShipIndex];

    public ShipSO this[int index] => shipList[index];

    public void ChangeShip(int index)
    {
        currentShipIndex = index;
        OnCurrentShipChangedEvent?.Invoke();
    }

    public event Action OnCurrentShipChangedEvent = null;
}
