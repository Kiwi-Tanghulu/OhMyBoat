using System;
using UnityEngine;

public class StagePoint : MonoBehaviour, IFocusable
{
    [SerializeField] StageSO stageData = null;

    public GameObject CurrentObject => gameObject;

    private StageInfoPanel infoPanel = null;

    private void Awake()
    {
        infoPanel = DEFINE.MainCanvas.Find("StageSelectPanel/StageInfoPanel").GetComponent<StageInfoPanel>();
    }

    public void Interact()
    {
        StageManager.Instance.StartStage(stageData);
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
}
