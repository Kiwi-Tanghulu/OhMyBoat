using System;
using UnityEngine;
using static ShopSO;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] Transform slotContainer = null;
    [SerializeField] StockSlot slotPrefab = null;
    [SerializeField] StockInfoPanel infoPanel = null;

    private StockSlot[] slots = null;
    private StockInfo focusedStock = null;
    public event Func<StockInfo, bool> OnPurchaseButtonClickedEvent = null;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Initialize(ShopSO shopData)
    {
        slots = new StockSlot[shopData.Count];

        for(int i = 0; i < shopData.Count; ++i)
        {
            StockSlot slot = Instantiate(slotPrefab, slotContainer);
            slot.Initialize(shopData[i], this);
            slots[i] = slot;
        }
    }

    public void Release()
    {
        if(slots == null)
            return;

        for(int i = 0; i < slots.Length; ++i)
        {
            slots[i].Release();
            Destroy(slots[i].gameObject);
        }

        slots = null;
        infoPanel.Release();
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    public void DisplayInfo(StockInfo stockInfo)
    {
        focusedStock = stockInfo;
        infoPanel.Initialize(focusedStock);
    }

    public void HandlePurchase()
    {
        OnPurchaseButtonClickedEvent?.Invoke(focusedStock);
    }
}
