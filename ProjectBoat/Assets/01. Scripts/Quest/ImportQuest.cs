using UnityEngine;

public partial class ImportQuest : Quest
{
    private ImportQuestSO questData = null;
    private bool anythingImported = false;

    private int[] soldList = null;
    private ImportQuestSlot[] uiList = null;

    public override void Initialize(QuestSpot spot, QuestSO questData)
    {
        base.Initialize(spot, questData);
        this.questData = questData as ImportQuestSO;
    }

    public override void StartQuest()
    {
        base.StartQuest();
        
        soldList = new int[questData.ImportSlips.Count];
        uiList = new ImportQuestSlot[questData.ImportSlips.Count];

        for(int i = 0; i < questData.ImportSlips.Count; ++i)
        {
            ImportSlip slip = questData.ImportSlips[i];
            ImportQuestSlot ui = progressPanel.CreateQuestSlot<ImportQuestSlot>(questData.uiPrefab);
            
            ui.Initialize(slip);
            uiList[i] = ui;
        }
    }

    public override void FinishQuest()
    {
        base.FinishQuest();

        for(int i = 0; i < uiList.Length; ++i)
            progressPanel.RemoveQuestSlot(uiList[i].transform);
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

        soldList[index]++;
        uiList[index].SetProgress(soldList[index]);

        ImportSlip slip = questData.ImportSlips[index];
        int price = slip.GetPrice();
        Debug.Log($"{price}$ earned!");
    }
}
