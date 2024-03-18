using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Ship/ShipData")]
public class ShipSO : ScriptableObject
{
	public string ShipName = "Nice Ship";
	[TextArea]
    public string Content = "unbubblelievable";

    [Space(15f)]
    // public Ship ShipPrefab = null;
    public GameObject ShipPrefab = null;
    public ShipStatSO ShipStat = null;

    [Space(15f)]
    public int BasePrice = 10000;
    [SerializeField] int level = 0;
    public int Level => level;
    public float PriceCoefficient = 1.5f;

    [Space(15f)]
    public bool IsPurchased = false;

    public void ModifyLevel(int amount)
    {
        level += amount;
        OnLevelChanged?.Invoke();
    }

    public int GetPrice() => Mathf.RoundToInt(BasePrice * Mathf.Pow(PriceCoefficient, level));
    public event Action OnLevelChanged = null;
}
