using System;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.OnGameStateChangedEvent += HandleGameStateChanged;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStateChangedEvent -= HandleGameStateChanged;
    }

    public void ReturnToStageSelectPanel()
    {
        StageManager.Instance.DestroyStage();
        DEFINE.StageBoard.SetActive(true);
        gameObject.SetActive(false);
    }

    private void HandleGameStateChanged(GameState state)
    {
        if(state != GameState.Finish)
            return;

        gameObject.SetActive(true);
        GameManager.Instance.CursorActive(true);
    }
}
