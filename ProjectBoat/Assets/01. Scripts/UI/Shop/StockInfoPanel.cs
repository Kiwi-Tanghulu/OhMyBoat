using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ShopSO;

public class StockInfoPanel : MonoBehaviour
{
	private Image iconImage = null;
    private TMP_Text nameText = null;
    private TMP_Text contentText = null;
    private TMP_Text priceText = null;
    private TMP_Text weightText = null;
    private Button purchaseButton = null;
    private Button cancelButton = null;

    private void Awake()
    {
        iconImage = transform.Find("IconImage").GetComponent<Image>();

        Transform textContainer = transform.Find("Texts");
        nameText = textContainer.Find("NameText").GetComponent<TMP_Text>();
        contentText = textContainer.Find("ContentText").GetComponent<TMP_Text>();

        Transform purchasePanel = transform.Find("PurchasePanel");
        purchaseButton = purchasePanel.Find("PurchaseButton").GetComponent<Button>();
        cancelButton = purchasePanel.Find("CancelButton").GetComponent<Button>();

        Transform infoPanel = textContainer.Find("InfoPanel");
        priceText = infoPanel.Find("PriceBlock/Text").GetComponent<TMP_Text>();
        weightText = infoPanel.Find("WeightBlock/Text").GetComponent<TMP_Text>();

        Release();
    }

    public void Initialize(StockInfo stockInfo)
    {
        StuffSO stuffData = stockInfo.StuffData;

        iconImage.color = Color.white;
        iconImage.sprite = stuffData.StuffIcon;

        nameText.text = stuffData.StuffName;
        contentText.text = stuffData.StuffContent;
        priceText.text = stockInfo.GetPrice().ToString();
        weightText.text = $"x {stuffData.Weight}";

        purchaseButton.interactable = true;
        cancelButton.interactable = true;
    }

    public void Release()
    {
        iconImage.color = new Color(1, 1, 1, 0);
        iconImage.sprite = null;

        nameText.text = "";
        contentText.text = "";
        priceText.text = "";
        weightText.text = "";

        purchaseButton.interactable = false;
        cancelButton.interactable = false;
    }
}
