using UnityEngine;

public partial class DeliveryQuest : Quest
{
    private DeliveryQuestSO questData = null;
    private int[] receivedList = null;

    public override void Initialize(QuestSpot spot, QuestSO questData)
    {
        base.Initialize(spot, questData);
        this.questData = questData as DeliveryQuestSO;

        receivedList = new int[this.questData.DeliverySlips.Count];
    }

    protected override bool DecisionClear()
    {
        for(int i = 0; i < questData.DeliverySlips.Count; ++i)
        {
            DeliverySlip slip = questData.DeliverySlips[i];
            int requires = slip.RequireQuantity;
            int received = receivedList[i];

            if(requires > received)
                return false;
        }

        return true;
    }

    protected override void OnQuestCleared()
    {
        Debug.Log("Quest Cleared");
    }

    protected override void OnQuestFailed()
    {
        Debug.Log("Quest Failed");
    }

    protected override void ProcessQuest(StuffSO stuffData)
    {
        int index = questData.DeliverySlips.FindIndex(i => i.RequireStuff == stuffData);   
        if(index == -1)
            return;

        receivedList[index]++;   
    }
}
