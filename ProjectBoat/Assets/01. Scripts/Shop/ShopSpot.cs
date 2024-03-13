using System;
using UnityEngine;

public class ShopSpot : MonoBehaviour, IInteractable
{
    [SerializeField] UIInputSO input = null;

    [Space(15f)]
    [SerializeField] ShopSO shopData = null;

    private bool isFocused = false;
    private ShopPanel shopPanel = null;

    public event Action<bool> OnFocusedEvent = null;

    private void Awake()
    {
        input.OnEscapeEvent += HandleEscape;
    }

    private void Start()
    {
        shopPanel = DEFINE.MainCanvas.Find("ShopPanel").GetComponent<ShopPanel>();
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
        shopPanel.Initialize(shopData);
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
}
