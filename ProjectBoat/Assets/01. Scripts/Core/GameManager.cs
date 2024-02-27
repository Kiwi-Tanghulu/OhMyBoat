using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public GameState GameState { get; private set; } = GameState.None;
    public event Action<GameState> OnGameStateChangedEvent = null;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;
        InputManager.ChangeInputMap(InputMapType.Play);
    }

    private void Start()
    {
        //Fader.Instance.FadeIn();

        CursorActive(false);
    }

    public void ChangeState(GameState state)
    {
        GameState = state;
        OnGameStateChangedEvent?.Invoke(GameState);
    }

    public void CursorActive(bool active)
    {
        if(active)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = active;
    }
}
