using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Shop/ShopData")]
public partial class ShopSO : ScriptableObject
{
	[SerializeField] List<StockInfo> stocks = null;
    public List<StockInfo> Stocks => stocks;
    public int Count => stocks.Count;

    public StockInfo this[int index] => stocks[index];
}
