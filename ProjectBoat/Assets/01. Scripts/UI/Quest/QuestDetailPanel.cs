using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestDetailPanel : MonoBehaviour
{
    private QuestProgressPanel progressPanel = null;
	private TMP_Text titleText = null;
    private TMP_Text contentText = null;
    private RawImage npcImage = null;

    private Quest quest = null;

    private void Awake()
    {
        progressPanel = transform.Find("SlipPanel/ScrollView/Viewport").GetComponent<QuestProgressPanel>();
        titleText = transform.Find("TopPanel/Background/TitleText").GetComponent<TMP_Text>();
        contentText = transform.Find("ContentPanel/ContentBox/ContentText").GetComponent<TMP_Text>();
        npcImage = transform.Find("ContentPanel/NPCImage").GetComponent<RawImage>();
    }

    private void Start()
    {
        Display(false);
    }

    public void Initialize(Quest quest)
    {
        this.quest = quest;

        QuestSO questData = quest.QuestData;
        contentText.text = questData.QuestContent;
        titleText.text = questData.QuestName;
        npcImage.texture = questData.npcImage;
        
        quest.InitProgressPanel(progressPanel);
    }

    public void StartQuest()
    {
        QuestManager.Instance.StartQuest(quest);
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }
}
