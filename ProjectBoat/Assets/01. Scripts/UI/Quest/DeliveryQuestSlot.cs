using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static DeliveryQuest;

public class DeliveryQuestSlot : MonoBehaviour
{
	private Image requireStuffIcon = null;
    private Image completeImage = null;
    private TMP_Text stuffNameText = null;
    private TMP_Text progressText = null;

    private DeliverySlip deliverySlip = null;

    private void Awake()
    {
        requireStuffIcon = transform.Find("RequireStuffIcon").GetComponent<Image>();
        stuffNameText = transform.Find("StuffNameText").GetComponent<TMP_Text>();

        Transform progressPanel = transform.Find("ProgressPanel");
        completeImage = progressPanel.Find("CompleteImage").GetComponent<Image>();
        progressText = progressPanel.Find("ProgressText").GetComponent<TMP_Text>();
    }

    public void Initialize(DeliverySlip slip)
    {
        deliverySlip = slip;
        requireStuffIcon.sprite = deliverySlip.RequireStuff.StuffIcon;
        stuffNameText.text = deliverySlip.RequireStuff.StuffName;

        progressText.text = $"0/{deliverySlip.RequireQuantity}";
    }

    public void SetProgress(int received)
    {
        progressText.text = $"{received}/{deliverySlip.RequireQuantity}";
        if(received >= deliverySlip.RequireQuantity)
            CompleteProgress();
    }

    public void CompleteProgress()
    {
        progressText.gameObject.SetActive(false);
        completeImage.gameObject.SetActive(true);
    }
}
