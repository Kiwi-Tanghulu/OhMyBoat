public abstract class Quest
{
    protected QuestSpot questSpot = null;
    protected QuestProgressPanel progressPanel = null;

    public virtual void Initialize(QuestSpot spot, QuestSO questData)
    {
        questSpot = spot;
        questSpot.OnQuestProcessEvent += ProcessQuest;

        progressPanel = QuestManager.Instance.QuestProgressPanel;
    }

    protected abstract bool DecisionClear();
    protected abstract void OnQuestCleared();
    protected abstract void OnQuestFailed();
    protected abstract bool ProcessQuest(StuffSO stuffData);

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
