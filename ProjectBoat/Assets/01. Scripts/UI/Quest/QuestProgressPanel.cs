using UnityEngine;

public class QuestProgressPanel : MonoBehaviour
{
	private Transform contentTransform = null;

    private void Awake()
    {
        contentTransform = transform.Find("Content");
    }

    public QuestSlot CreateQuestSlot(QuestSlot slotPrefab)
    {
        QuestSlot slot = Instantiate(slotPrefab, contentTransform);
        return slot;
    }

    public void Clear()
    {
        foreach(Transform child in contentTransform)
            Destroy(child.gameObject);
    }

    public void RemoveQuestSlot(Transform questSlot)
    {
        Destroy(questSlot.gameObject); // tweening later
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }
}
