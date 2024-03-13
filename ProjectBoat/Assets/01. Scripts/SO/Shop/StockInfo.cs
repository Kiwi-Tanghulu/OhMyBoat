using System;
using UnityEngine;

public partial class ShopSO
{
    [System.Serializable]
    public class StockInfo
    {
        public StuffSO StuffData;
        public float PriceCoefficient;
        [SerializeField] int stockCount;
        public int StockCount => stockCount;

        public Action<int> OnStockCountChanged = null;

        public void ModifyCount(int amount)
        {
            stockCount += amount;
            OnStockCountChanged?.Invoke(stockCount);
        }

        public int GetPrice() => Mathf.RoundToInt(StuffData.Price * PriceCoefficient);
    }
}
