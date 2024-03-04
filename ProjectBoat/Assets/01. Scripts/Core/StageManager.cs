using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;

    public Action<Stage, bool> OnStageEndEvent;

    private Stage currentStage = null;
    public Stage CurrentStage => currentStage;

    public float PlayingTime => currentStage.PlayingTime;

    private void Awake()
    {
        if(Instance != null)
            Destroy(Instance);

        Instance = this;
    }

    public void StartStage(StageSO stageData)
    {
        DEFINE.StageBoard.SetActive(false);
        
        currentStage = Instantiate(stageData.StagePrefab, Vector3.zero, Quaternion.identity);
        currentStage.StartStage();
    }

    public void DestroyStage()
    {
        if(currentStage)
            Destroy(currentStage.gameObject);

        currentStage = null;
    }
}
