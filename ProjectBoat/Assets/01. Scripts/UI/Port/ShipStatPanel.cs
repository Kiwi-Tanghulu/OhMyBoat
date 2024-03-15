using TMPro;
using UnityEngine;
using static ShipStatPanel.DisplayFormat;

public partial class ShipStatPanel : MonoBehaviour
{
	private TMP_Text nameText = null;
	private TMP_Text contentText = null;
	private TMP_Text durabilityText = null;
	private TMP_Text rateOfTurnText = null;
	private TMP_Text topSpeedText = null;
	private TMP_Text accelSpeedText = null;
	private TMP_Text weightText = null;

    private void Awake()
    {
        Transform topPanel = transform.Find("Panels/TopPanel");
        Transform statPanel = transform.Find("Panels/StatPanel/ContentPanel");

        nameText = topPanel.Find("NameText").GetComponent<TMP_Text>();
        contentText = topPanel.Find("ContentText").GetComponent<TMP_Text>();
        
        durabilityText = statPanel.Find("DurabilityText").GetComponent<TMP_Text>();
        rateOfTurnText = statPanel.Find("RateOfTurnText").GetComponent<TMP_Text>();
        topSpeedText = statPanel.Find("TopSpeedText").GetComponent<TMP_Text>();
        accelSpeedText = statPanel.Find("AccelSpeedText").GetComponent<TMP_Text>();
        weightText = statPanel.Find("WeightText").GetComponent<TMP_Text>();
    }

    public void Initialize(ShipSO shipData)
    {
        ShipStatSO stat = shipData.ShipStat;

        nameText.text = string.Format(NameFormat, shipData.ShipName);
        contentText.text = string.Format(ContentFormat, shipData.Content);

        durabilityText.text = string.Format(DurabilityFormat, stat.Durability.CurrentValue);
        rateOfTurnText.text = string.Format(RateOfTurnFormat, stat.RateOfTurn.CurrentValue);
        topSpeedText.text = string.Format(TopSpeedFormat, stat.TopSpeed.CurrentValue);
        accelSpeedText.text = string.Format(AccelSpeedFormat, stat.AccelSpeed.CurrentValue);
        weightText.text = string.Format(WeightFormat, stat.Weight.CurrentValue);
    }
}
