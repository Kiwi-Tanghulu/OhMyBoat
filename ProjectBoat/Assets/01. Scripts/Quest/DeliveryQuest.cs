using System;
using UnityEngine;

public partial class DeliveryQuest : Quest
{
    private DeliveryQuestSO questData = null;
    
    private int[] receivedList = null;
    private DeliveryQuestSlot[] uiList = null;

    public override void Initialize(QuestSpot spot, QuestSO questData)
    {
        base.Initialize(spot, questData);
        this.questData = questData as DeliveryQuestSO;
    }

    public override void StartQuest()
    {
        base.StartQuest();
        
        receivedList = new int[questData.DeliverySlips.Count];
        uiList = new DeliveryQuestSlot[questData.DeliverySlips.Count];

        InitProgressPanel(progressPanel, (i, slot) => uiList[i] = slot as DeliveryQuestSlot);
    }

    public override void FinishQuest()
    {
        base.FinishQuest();

        for(int i = 0; i < uiList.Length; ++i)
            progressPanel.RemoveQuestSlot(uiList[i].transform);
    }

    public override void InitProgressPanel(QuestProgressPanel progressPanel, Action<int, QuestSlot> callback = null)
    {
        progressPanel.Clear();

        for(int i = 0; i < questData.DeliverySlips.Count; ++i)
        {
            DeliverySlip slip = questData.DeliverySlips[i];
            DeliveryQuestSlot ui = progressPanel.CreateQuestSlot(questData.UIPrefab) as DeliveryQuestSlot;
            
            ui.Initialize(slip);
            callback?.Invoke(i, ui);
        }
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

    protected override bool ProcessQuest(StuffSO stuffData)
    {
        int index = questData.DeliverySlips.FindIndex(i => i.RequireStuff == stuffData);   
        if(index == -1)
            return false;

        if(receivedList[index] >= questData.DeliverySlips[index].RequireQuantity)
            return false;

        receivedList[index]++;
        uiList[index].SetProgress(receivedList[index]);
        
        return true;
    }
}
