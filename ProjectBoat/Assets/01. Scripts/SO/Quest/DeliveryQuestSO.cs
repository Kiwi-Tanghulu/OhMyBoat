using System.Collections.Generic;
using UnityEngine;
using static DeliveryQuest;

[CreateAssetMenu(menuName = "SO/Quest/DeliveryQuestData")]
public class DeliveryQuestSO : QuestSO
{
    public List<DeliverySlip> DeliverySlips = new List<DeliverySlip>();
}
