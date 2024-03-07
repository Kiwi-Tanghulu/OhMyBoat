using UnityEngine;

public class DeliveryQuest : Quest
{
    private DeliveryQuestSO questData = null;
    private int receivedCount = 0;

    public override void Initialize(QuestSpot spot, QuestSO questData)
    {
        base.Initialize(spot, questData);
        this.questData = questData as DeliveryQuestSO;
    }

    protected override bool DecisionClear()
    {
        bool cleared = receivedCount >= questData.RequireQuantity;
        return cleared;
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
        if(stuffData != questData.RequireStuff)
            return;

        receivedCount++;   
    }
}
