using UnityEngine;
using UnityEngine.UI;

public class QuestBoardSlot : MonoBehaviour
{
    private Button detailButton = null;
    private QuestDetailPanel detailPanel = null;

    private Quest quest = null;

    private void Awake()
    {
        detailButton = transform.Find("DetailButton").GetComponent<Button>();
        detailPanel = DEFINE.MainCanvas.Find("QuestDetailPanel").GetComponent<QuestDetailPanel>();

        detailButton.onClick.AddListener(HandleDetailButtonClicked);
    }

    public void Initialize(Quest quest)
    {
        this.quest = quest;
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    private void HandleDetailButtonClicked()
    {
        detailPanel.Display(true);
        detailPanel.Initialize(quest);
    }
}
