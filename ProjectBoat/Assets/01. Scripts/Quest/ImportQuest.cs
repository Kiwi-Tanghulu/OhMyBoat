using UnityEngine;

public partial class ImportQuest : Quest
{
    private ImportQuestSO questData = null;
    private bool anythingImported = false;

    public override void Initialize(QuestSpot spot, QuestSO questData)
    {
        base.Initialize(spot, questData);
        this.questData = questData as ImportQuestSO;
    }

    protected override bool DecisionClear()
    {
        return anythingImported;
    }

    protected override void OnQuestCleared()
    {
        Debug.Log("Quest Cleared");
    }

    protected override void OnQuestFailed()
    {
        Debug.Log("Nothing Sold, Quest Failed");
    }

    protected override void ProcessQuest(StuffSO stuffData)
    {
        int index = questData.ImportSlips.FindIndex(i => i.RequireStuff == stuffData);
        if(index == -1)
            return;

        if(anythingImported == false)
            anythingImported = true;

        ImportSlip slip = questData.ImportSlips[index];
        int price = Mathf.RoundToInt(stuffData.Price * slip.PriceCoefficient);
        Debug.Log($"{price}$ earned!");
    }
}
