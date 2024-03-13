using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] Transform slotContainer = null;
    [SerializeField] StockSlot slotPrefab = null;
    private StockSlot[] slots = null;

    [SerializeField] ShopSO test;

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.GetKeyDown(KeyCode.F))
                Initialize(test);
            if(Input.GetKeyDown(KeyCode.Alpha0))
                test[0].ModifyCount(-1);
        }
    }

    public void Initialize(ShopSO shopData)
    {
        slots = new StockSlot[shopData.Count];

        for(int i = 0; i < shopData.Count; ++i)
        {
            StockSlot slot = Instantiate(slotPrefab, slotContainer);
            slot.Initialize(shopData[i]);
            slots[i] = slot;
        }
    }

    public void Clear()
    {
        for(int i = 0; i < slots.Length; ++i)
        {
            slots[i].Release();
            Destroy(slots[i].gameObject);
        }

        slots = null;
    }
}
