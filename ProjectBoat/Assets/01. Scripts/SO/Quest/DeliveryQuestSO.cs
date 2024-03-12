using System.Collections.Generic;
using UnityEngine;
using static DeliveryQuest;

[CreateAssetMenu(menuName = "SO/Quest/DeliveryQuestData")]
public class DeliveryQuestSO : QuestSO
{
    [Space(15f)]
    public List<DeliverySlip> DeliverySlips = new List<DeliverySlip>();

    public override Quest CreateQuest(QuestSpot spot)
    {
        Quest quest = new DeliveryQuest();
        quest.Initialize(spot, this);
        
        return quest;
    }
}
