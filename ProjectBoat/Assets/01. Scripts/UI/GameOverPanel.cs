using System;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] TMP_Text resultText = null;

    private void Start()
    {
        StageManager.Instance.OnStageEndEvent += HandleStageEnd;

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        StageManager.Instance.OnStageEndEvent -= HandleStageEnd;
    }

    public void ReturnToStageSelectPanel()
    {
        StageManager.Instance.DestroyStage();
        DEFINE.StageBoard.SetActive(true);
        gameObject.SetActive(false);
    }

    private void HandleStageEnd(Stage stage, bool complete)
    {
        resultText.text = complete ? "STAGE CLEAR!" : "STAGE FAILED!";

        gameObject.SetActive(true);
        GameManager.Instance.CursorActive(true);
    }
}
