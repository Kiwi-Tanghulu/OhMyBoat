using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance = null;

    #region Test Codes
    public QuestSpot questSpot = null;
    public QuestSO questData = null;
    private Quest quest = null;
    #endregion

    private QuestProgressPanel questProgressPanel = null;
    public QuestProgressPanel QuestProgressPanel => questProgressPanel;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;

        questProgressPanel = DEFINE.MainCanvas.Find("QuestProgressPanel").GetComponent<QuestProgressPanel>();
    }

    #region Test Codes
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                quest = new DeliveryQuest();
                quest.Initialize(questSpot, questData);
                quest.StartQuest();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                quest = new ImportQuest();
                quest.Initialize(questSpot, questData);
                quest.StartQuest();
            }

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                if (quest == null)
                    return;

                questSpot.FinishQuest();
            }
        }
    }
    #endregion

    public void CreateQuest()
    {
        
    }
}
