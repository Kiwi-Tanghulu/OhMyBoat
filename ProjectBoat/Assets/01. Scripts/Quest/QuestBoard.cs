using System;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class QuestBoard : MonoBehaviour, IInteractable
{
    [SerializeField] UIInputSO input = null;
    
    [Space(15f)]
    [SerializeField] List<QuestSpot> questSpots = null;

    private const int FOCUSED_PRIORITY = 20;
    private const int UNFOCUSED_PRIORITY = 1;

    public event Action<bool> OnFocusedEvent = null;

    private CinemachineVirtualCamera focusedVCam = null;
    private QuestBoardPanel boardUI = null;
    private bool isFocused = false;

    private void Awake()
    {
        focusedVCam = transform.Find("FocusedVCam").GetComponent<CinemachineVirtualCamera>();
        boardUI = transform.Find("Canvas/Board").GetComponent<QuestBoardPanel>();
        
        input.OnEscapeEvent += HandleEscape;

        
    }

    private void Start()
    {
        for (int i = 0; i < 4; ++i)
            boardUI.InitailizeSlot(CreateQuest(), i);
    }

    private void OnDestroy()
    {
        input.OnEscapeEvent -= HandleEscape;
    }

    public bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        if(actived == false)
            return false;

        if(isFocused)
            return false;

        InputManager.ChangeInputMap(InputMapType.UI);
        ToggleFocus(true);

        return true;
    }

    private void ToggleFocus(bool focus)
    {
        isFocused = focus;

        focusedVCam.gameObject.SetActive(focus);
        focusedVCam.Priority = focus ? FOCUSED_PRIORITY : UNFOCUSED_PRIORITY;

        boardUI.Display(isFocused);
        GameManager.Instance.CursorActive(isFocused);
        
        OnFocusedEvent?.Invoke(isFocused);
    }

    private Quest CreateQuest()
    {
        QuestSpot spot = questSpots?.PickRandom();
        Quest quest = spot?.CreateQuest();
        return quest;
    }

    public void Release()
    {
        InputManager.ChangeInputMap(InputMapType.Play);
        ToggleFocus(false);
    }

    private void HandleEscape()
    {
        Release();   
    }
}
