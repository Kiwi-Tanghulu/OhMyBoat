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

        MissonManager.Instance.OnStartMisson += HandleMissionStart;
        MissonManager.Instance.OnEndMisson += HandleMissionEnd;
    }

    public void EndStage(bool complete)
    {
        isPlaying = false;

        GameManager.Instance.ChangeState(GameState.Finish);

        MissonManager.Instance.OnStartMisson -= HandleMissionStart;
        MissonManager.Instance.OnEndMisson -= HandleMissionEnd;

        StageManager.Instance.OnStageEndEvent?.Invoke(this, complete);
    }

    private void HandleMissionStart(MissonType type)
    {
        accumMissionCount++;
    }

    private void HandleMissionEnd(MissonType type)
    {
        accumMissionCount--;
    }
}
