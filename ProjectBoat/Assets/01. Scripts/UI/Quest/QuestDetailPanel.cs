using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestDetailPanel : MonoBehaviour
{
    private QuestProgressPanel progressPanel = null;
	private TMP_Text titleText = null;
    private TMP_Text contentText = null;
    private RawImage npcImage = null;

    public QuestSpot a;
    public QuestSO b;

    private void Awake()
    {
        progressPanel = transform.Find("SlipPanel/ScrollView/Viewport").GetComponent<QuestProgressPanel>();
        titleText = transform.Find("TopPanel/TitleText").GetComponent<TMP_Text>();
        contentText = transform.Find("ContentPanel/ContentBox/ContentText").GetComponent<TMP_Text>();
        npcImage = transform.Find("ContentPanel/NPCImage").GetComponent<RawImage>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Quest quest = new DeliveryQuest();
            quest.Initialize(a, b);

            Initialize(quest);
        }
    }

    public void Initialize(Quest quest)
    {
        QuestSO questData = quest.QuestData;
        contentText.text = questData.QuestContent;
        titleText.text = questData.QuestName;
        npcImage.texture = questData.npcImage;
        
        quest.InitProgressPanel(progressPanel);
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }
}
