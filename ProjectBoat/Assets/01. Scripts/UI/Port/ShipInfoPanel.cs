using System;
using TMPro;
using UnityEngine;
using static ShipInfoPanel.DisplayFormat;

public partial class ShipInfoPanel : MonoBehaviour
{
    [SerializeField] PortSO portData = null;

	private TMP_Text nameText = null;
	private TMP_Text contentText = null;
	private TMP_Text durabilityText = null;
	private TMP_Text rateOfTurnText = null;
	private TMP_Text topSpeedText = null;
	private TMP_Text accelSpeedText = null;
	private TMP_Text weightText = null;

    private ShipSO focusedShipData = null;

    private void Awake()
    {
        Transform topPanel = transform.Find("TopPanel");
        Transform statPanel = transform.Find("StatPanel/ContentPanel");

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
        focusedShipData = shipData;
        focusedShipData.OnLevelChanged += HandleLevelChanged;
        
        FillText();
    }

    public void Release()
    {
        focusedShipData.OnLevelChanged -= HandleLevelChanged;
    }

    private void FillText()
    {
        ShipStatSO stat = focusedShipData.ShipStat;

        string level = focusedShipData.Level > 1 ? $" +{focusedShipData.Level - 1}" : "";
        nameText.text = string.Format(NameFormat, focusedShipData.ShipName, level);
        contentText.text = string.Format(ContentFormat, focusedShipData.Content);

        durabilityText.text = string.Format(DurabilityFormat, stat.Durability.CurrentValue);
        rateOfTurnText.text = string.Format(RateOfTurnFormat, stat.RateOfTurn.CurrentValue);
        topSpeedText.text = string.Format(TopSpeedFormat, stat.TopSpeed.CurrentValue);
        accelSpeedText.text = string.Format(AccelSpeedFormat, stat.AccelSpeed.CurrentValue);
        weightText.text = string.Format(WeightFormat, stat.Weight.CurrentValue);
    }

    private void HandleLevelChanged()
    {
        FillText();
    }
}
