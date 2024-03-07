using UnityEngine;

public class QuestBoardPanel : MonoBehaviour
{
	private QuestSlot[] questSlots = null;

    private void Awake()
    {
        questSlots = transform.GetComponentsInChildren<QuestSlot>();
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
