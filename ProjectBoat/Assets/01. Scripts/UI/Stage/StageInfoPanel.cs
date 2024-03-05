using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageInfoPanel : MonoBehaviour
{
    private StageStar[] stars = null;
    private TMP_Text captionText = null;
    private Image stageImage = null;

    private Camera mainCamera = null;

    private bool active = false;
    private Vector3 targetWorldPoint = Vector3.zero;
    private readonly Vector3 OFFSET = new Vector3(0f, 50f, 0f);

    private void Awake()
    {
        stars = transform.Find("Background/StarBoard").GetComponentsInChildren<StageStar>();
        stageImage = transform.Find("Background/StageImage").GetComponent<Image>();
        captionText = transform.Find("Background/TextBoard/CaptionText").GetComponent<TMP_Text>();

        mainCamera = Camera.main;
    }

    private void Start()
    {
        gameObject.SetActive(false);
        active = false;
    }

    private void FixedUpdate()
    {
        if(active == false)
            return;

        transform.position = mainCamera.WorldToScreenPoint(targetWorldPoint) + OFFSET;
    }

    public void SetStageData(StageSO stageData, Vector3 worldPoint)
    {
        targetWorldPoint = worldPoint;
        transform.position = mainCamera.WorldToScreenPoint(targetWorldPoint) + OFFSET;

        for(int i = 0; i < stageData.EarnedStar; ++i)
            stars[i].Display(true);

        captionText.SetText(stageData.StageCaption);
        stageImage.sprite = stageData.StageImage;
    }

    public void Display(bool active)
    {
        if(active)
            Show();
        else
            Hide();
    
        this.active = active;
    }

    public void DisplayReady()
    {
        captionText.text  = "READY";
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        captionText.text = "";
    }
}
