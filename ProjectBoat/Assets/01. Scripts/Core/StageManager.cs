using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;

    [SerializeField] StageListSO stageList = null;

    private GameObject currentStage = null;
    private StageSO stageInfo = null;

    private float playTime = 0f;
    public float PlayTime => playTime;

    private void Awake()
    {
        if(Instance != null)
            Destroy(Instance);

        Instance = this;
    }

    private void Update()
    {
        if(GameManager.Instance.GameState != GameState.Playing)
            return;

        playTime += Time.deltaTime;
        if(playTime >= stageInfo.PlayTime)
            GameManager.Instance.ChangeState(GameState.Finish);
    }

    public void StartStage(int index)
    {
        DEFINE.StageBoard.SetActive(false);
        GameManager.Instance.ChangeState(GameState.Playing);
        
        stageInfo = stageList[index];
        currentStage = Instantiate(stageInfo.StagePrefab, Vector3.zero, Quaternion.identity);
        playTime = 0f;
    }

    public void DestroyStage()
    {
        if(currentStage)
            Destroy(currentStage);
    }
}
