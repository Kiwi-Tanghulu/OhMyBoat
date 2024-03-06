using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance = null;

    #region Test Codes
    public QuestSpot questSpot = null;
    public QuestSO questData = null;
    private Quest quest = null;
    #endregion

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                quest = new DeliveryQuest();
                quest.Initialize(questSpot, questData);
                quest.StartQuest();
            }

            if(Input.GetKeyDown(KeyCode.X))
            {
                if(quest == null)
                    return;

                quest.FinishQuest();
            }
        }
    }

    public void CreateQuest()
    {
        
    }
}
