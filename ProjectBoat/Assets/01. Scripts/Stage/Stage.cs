using System;
using UnityEngine;

public class Stage : MonoBehaviour
{
	[SerializeField] StageSO stageInfo = null;
    public StageSO StageInfo => stageInfo;

    private float playingTime = 0f;
    public float PlayingTime => playingTime;

    private int accumMissionCount = 0;
    private float damage = 0f;
    public float Damage => damage;

    private bool isPlaying = false;

    private void Update()
    {
        if(isPlaying == false)
            return;

        damage += accumMissionCount * stageInfo.DamageFactor * Time.deltaTime;
        if(damage >= stageInfo.DamageLimit)
            EndStage(false); // stage failed due to excessive damage

        playingTime += Time.deltaTime;
        if(playingTime >= stageInfo.PlayTime)
            EndStage(true); // stage complete
    }

    public void StartStage()
    {
        isPlaying = true;

        GameManager.Instance.ChangeState(GameState.Playing);

        MissionManager.Instance.OnStartMission += HandleMissionStart;
        MissionManager.Instance.OnEndMission += HandleMissionEnd;
    }

    public void EndStage(bool complete)
    {
        isPlaying = false;

        GameManager.Instance.ChangeState(GameState.Finish);

        MissionManager.Instance.OnStartMission -= HandleMissionStart;
        MissionManager.Instance.OnEndMission -= HandleMissionEnd;

        StageManager.Instance.OnStageEndEvent?.Invoke(this, complete);
    }

    private void HandleMissionStart(MissionType type)
    {
        accumMissionCount++;
    }

    private void HandleMissionEnd(MissionType type, bool isSuccess)
    {
        accumMissionCount--;
    }
}
