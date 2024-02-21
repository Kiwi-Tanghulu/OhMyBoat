using TMPro;
using UnityEngine;

public class TestClock : MonoBehaviour
{
    [SerializeField] TMP_Text timeText = null;

	private void Start()
    {
        GameManager.Instance.OnGameStateChangedEvent += HandleGameStateChanged;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(GameManager.Instance.GameState != GameState.Playing)
            return;

        StageManager stageManager = StageManager.Instance;
        Stage currentStage = stageManager.CurrentStage;
        string text = $"{stageManager.PlayingTime.ToString("0.0")}\n{currentStage.Damage.ToString("0.0")}/{currentStage.StageInfo.DamageLimit.ToString("0.0")}";
        timeText.text = text;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateChangedEvent -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameState state)
    {
        gameObject.SetActive(state == GameState.Playing);
    }
}
