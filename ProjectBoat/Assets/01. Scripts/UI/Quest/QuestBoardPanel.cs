using UnityEngine;

public class QuestBoardPanel : MonoBehaviour
{
    #region Test Codes
    public QuestSpot spot;
    public QuestSO questData;
    #endregion

	private QuestBoardSlot[] questSlots = null;

    private void Awake()
    {
        questSlots = transform.GetComponentsInChildren<QuestBoardSlot>();
    }

    private void Start()
    {
        #region Test Codes
        Quest quest = new DeliveryQuest();
        quest.Initialize(spot, questData);

        for(int i = 0; i < questSlots.Length; ++i)
            questSlots[i].Initialize(quest);
        #endregion

        Display(false);
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);

        for(int i = 0; i < questSlots.Length; ++i)
            questSlots[i].Display(active);
    }
}
