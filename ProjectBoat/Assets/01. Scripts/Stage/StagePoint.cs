using System;
using UnityEngine;

public class StagePoint : MonoBehaviour, IFocusable
{
    [SerializeField] StageSO stageData = null;

    public GameObject CurrentObject => gameObject;

    private StageInfoPanel infoPanel = null;

    private bool isReady = false;

    private void Awake()
    {
        infoPanel = DEFINE.MainCanvas.Find("StageSelectPanel/StageInfoPanel").GetComponent<StageInfoPanel>();
    }

    public void Interact()
    {
        if(isReady)
            StartStage();
        else
            ReadyStage();
    }

    public void OnFocusBegin(Vector3 point)
    {
        if(stageData == null)
            return;

        infoPanel.SetStageData(stageData, transform.position);
        infoPanel.Display(true);
        // UI 키기
    }

    public void OnFocusEnd()
    {
        infoPanel.Display(false);
        // UI 끄기
    }

    private void ReadyStage()
    {
        isReady = true;
        infoPanel.DisplayReady();
    }

    private void StartStage()
    {
        StageManager.Instance.StartStage(stageData);
        infoPanel.Display(false);
    }
}
