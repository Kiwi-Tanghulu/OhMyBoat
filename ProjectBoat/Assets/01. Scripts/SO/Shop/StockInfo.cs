using UnityEngine;

public partial class ShopSO
{
    [System.Serializable]
    public class StockInfo
    {
        public StuffSO StuffData;
        public int StockCount;
        public float PriceCoefficient;

        public int GetPrice() => Mathf.RoundToInt(StuffData.Price * PriceCoefficient);
    }
}
