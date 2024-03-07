using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static ImportQuest;

public class ImportQuestSlot : MonoBehaviour
{
	private Image requireStuffIcon = null;
    private TMP_Text stuffNameText = null;
    private TMP_Text priceText = null;
    private TMP_Text progressText = null;

    private ImportSlip importSlip = null;

    private void Awake()
    {
        requireStuffIcon = transform.Find("RequireStuffIcon").GetComponent<Image>();
        stuffNameText = transform.Find("StuffNameText").GetComponent<TMP_Text>();
        priceText = transform.Find("PriceText").GetComponent<TMP_Text>();
        progressText = transform.Find("ProgressText").GetComponent<TMP_Text>();
    }

    public void Initialize(ImportSlip slip)
    {
        importSlip = slip;
        requireStuffIcon.sprite = importSlip.RequireStuff.StuffIcon;
        stuffNameText.text = importSlip.RequireStuff.StuffName;

        int priceDiff = importSlip.GetPriceDiff();
        string sign = priceDiff > 0 ? "+" : "";
        priceText.text = $"{sign}{priceDiff}\n{importSlip.RequireStuff.Price}";

        progressText.text = "0";
    }

    public void SetProgress(int sold)
    {
        progressText.text = $"{sold}";
    }
}
