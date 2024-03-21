using System;
using UnityEngine;
using UnityEngine.Events;

public class ShopSpot : MonoBehaviour, IInteractable
{
    [SerializeField] UIInputSO input = null;
    [SerializeField] PlayerWalletSO wallet = null;

    [Space(15f)]
    [SerializeField] ShopSO shopData = null;
    [SerializeField] Transform spawnPoint = null;

    [Space(15f)]
    public UnityEvent OnShopOpenedEvent = null;
    public UnityEvent OnShopClosedEvent = null;

    private ShopSO liveShopData = null;
    private ShopPanel shopPanel = null;
    private bool isFocused = false;

    public event Action<bool> OnFocusedEvent = null;

    private void Awake()
    {
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
        OnShopOpenedEvent?.Invoke();
        input.OnEscapeEvent += HandleEscape;
    }

    private void Release()
    {
        shopPanel.Release();
        InputManager.ChangeInputMap(InputMapType.Play);
        OnShopClosedEvent?.Invoke();
        input.OnEscapeEvent -= HandleEscape;
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
