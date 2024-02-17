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

        timeText.text = StageManager.Instance.PlayTime.ToString("0.0");
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
