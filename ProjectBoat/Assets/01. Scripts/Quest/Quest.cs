using System;

public abstract class Quest
{
    public QuestSO QuestData { get; private set; } = null;
    protected QuestSpot questSpot = null;
    protected QuestProgressPanel progressPanel = null;

    public virtual void Initialize(QuestSpot spot, QuestSO questData)
    {
        questSpot = spot;
        questSpot.OnQuestProcessEvent += ProcessQuest;

        QuestData = questData;

        progressPanel = QuestManager.Instance.QuestProgressPanel;
    }

    protected abstract bool DecisionClear();
    protected abstract void OnQuestCleared();
    protected abstract void OnQuestFailed();
    protected abstract bool ProcessQuest(StuffSO stuffData);

    public abstract void InitProgressPanel(QuestProgressPanel progressPanel, Action<int, QuestSlot> callback = null);

    public virtual void StartQuest()
    {
        questSpot.StartQuest(this);
    }

    public virtual void FinishQuest()
    {
        bool questCleared = DecisionClear();
        if (questCleared)
            OnQuestCleared();
        else
            OnQuestFailed();

        questSpot.OnQuestProcessEvent -= ProcessQuest;
        questSpot = null;
    }
}
