using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipPurchasePanel : MonoBehaviour
{
    private const string PriceFormat = "[ {0} $ ]";
    
    private TMP_Text priceText = null;
    private Button purchaseButton = null;
    public event Action OnPurchaseEvent = null;

    private void Awake()
    {
        priceText = transform.Find("PriceText").GetComponent<TMP_Text>();
        purchaseButton = transform.Find("PurchaseButton").GetComponent<Button>();

        purchaseButton.onClick.AddListener(HandlePurchase);
        Display(false);
    }

    public void SetPrice(int price)
    {
        if(price == -1)
        {
            purchaseButton.interactable = false;
            priceText.text = "[ - ]";
        }
        else
        {
            purchaseButton.interactable = true;
            priceText.text = string.Format(PriceFormat, price.ToString("N0"));
        }
    }

    private void HandlePurchase()
    {
        OnPurchaseEvent?.Invoke();
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }
}
