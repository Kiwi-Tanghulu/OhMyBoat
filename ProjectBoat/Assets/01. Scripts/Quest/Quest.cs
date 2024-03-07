public abstract class Quest
{
    protected QuestSpot questSpot = null;


    public virtual void Initialize(QuestSpot spot, QuestSO questData)
    {
        questSpot = spot;
        questSpot.OnQuestProcessEvent += ProcessQuest;
    }

    protected abstract bool DecisionClear();
    protected abstract void OnQuestCleared();
    protected abstract void OnQuestFailed();
    protected abstract void ProcessQuest(StuffSO stuffData);

    public void StartQuest()
    {
        questSpot.StartQuest(this);
    }

    public void FinishQuest()
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
