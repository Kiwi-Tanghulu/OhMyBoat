using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ShopSO;

public class StockSlot : MonoBehaviour
{
    private Image iconImage = null;
    private TMP_Text nameText = null;
    private TMP_Text priceText = null;
    private TMP_Text countText = null;

	public StuffSO StuffData {get; private set;} = null;

    private void Awake()
    {
        iconImage = transform.Find("IconImage").GetComponent<Image>();
        nameText = transform.Find("NameText").GetComponent<TMP_Text>();
        priceText = transform.Find("PriceText").GetComponent<TMP_Text>();
        countText = transform.Find("CountText").GetComponent<TMP_Text>();
    }

    public void Initialize(StockInfo info)
    {
        StuffData = info.StuffData;

        iconImage.sprite = StuffData.StuffIcon;
        nameText.text = StuffData.StuffName;
        priceText.text = StuffData.Price.ToString();
        countText.text = info.GetPrice().ToString();
    }

    public void ModifyCount(int count)
    {
        countText.text = count.ToString();
    }
}
