using System;
using UnityEngine;

public class ShopSpot : MonoBehaviour, IInteractable
{
    [SerializeField] UIInputSO input = null;
    [SerializeField] PlayerWalletSO wallet = null;

    [Space(15f)]
    [SerializeField] ShopSO shopData = null;
    [SerializeField] Transform spawnPoint = null;

    private ShopSO liveShopData = null;
    private bool isFocused = false;
    private ShopPanel shopPanel = null;

    public event Action<bool> OnFocusedEvent = null;

    private void Awake()
    {
        input.OnEscapeEvent += HandleEscape;
        RestockShop();
    }

    private void Start()
    {
        shopPanel = DEFINE.MainCanvas.Find("ShopPanel").GetComponent<ShopPanel>();
        shopPanel.OnPurchaseButtonClickedEvent += HandlePurchase;
    }

    public void RestockShop()
    {
        liveShopData = ScriptableObject.Instantiate(shopData);
    }

    public bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        if(actived == false)
            return false;

        ToggleFocus(true);

        return true;
    }

    private void ToggleFocus(bool focus)
    {
        isFocused = focus;

        shopPanel.Display(isFocused);
        if (isFocused)
            Initialize();
        else
            Release();

        GameManager.Instance.CursorActive(isFocused);
        
        OnFocusedEvent?.Invoke(isFocused);
    }

    private void Initialize()
    {
        shopPanel.Initialize(liveShopData);
        InputManager.ChangeInputMap(InputMapType.UI);
    }

    private void Release()
    {
        shopPanel.Release();
        InputManager.ChangeInputMap(InputMapType.Play);
    }

    private void HandleEscape()
    {
        ToggleFocus(false);
    }

    private bool HandlePurchase(StockInfo info)
    {
        if(info.StockCount <= 0)
            return false;

        int price = info.GetPrice();
        if(wallet.CheckEnough(price) == false)
            return false;

        Instantiate(info.StuffData.Prefab, spawnPoint.position, Quaternion.identity);
        info.ModifyCount(-1);
        wallet.ModifyMoney(-price);

        return true;
    }
}
