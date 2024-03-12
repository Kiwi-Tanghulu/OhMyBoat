using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance = null;

    private Quest currentQuest = null;
    public bool QuestActive => currentQuest == null;

    private QuestProgressPanel questProgressPanel = null;
    public QuestProgressPanel QuestProgressPanel => questProgressPanel;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;

        questProgressPanel = DEFINE.MainCanvas.Find("QuestProgressPanel").GetComponent<QuestProgressPanel>();
    }

    public void StartQuest(Quest quest)
    {
        currentQuest = quest;
        currentQuest.StartQuest();
    }
}
