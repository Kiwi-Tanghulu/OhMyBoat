using UnityEngine;

public class QuestBoardPanel : MonoBehaviour
{
	private QuestBoardSlot[] questSlots = null;

    private void Awake()
    {
        questSlots = transform.GetComponentsInChildren<QuestBoardSlot>();
    }

    private void Start()
    {
        Display(false);
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);

        for(int i = 0; i < questSlots.Length; ++i)
            questSlots[i].Display(active);
    }
}
