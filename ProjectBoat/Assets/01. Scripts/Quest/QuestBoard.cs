using System;
using Cinemachine;
using UnityEngine;

public class QuestBoard : MonoBehaviour, IInteractable
{
    [SerializeField] UIInputSO input = null;

    private const int FOCUSED_PRIORITY = 10;
    private const int UNFOCUSED_PRIORITY = 1;

    public event Action<bool> OnFocusedEvent = null;

    private CinemachineVirtualCamera focusedVCam = null;
    private QuestBoardPanel boardUI = null;
    private bool isFocused = false;

    private void Awake()
    {
        focusedVCam = transform.Find("FocusedVCam").GetComponent<CinemachineVirtualCamera>();
        boardUI = transform.Find("Canvas/Board").GetComponent<QuestBoardPanel>();
    }

    private void Start()
    {
        input.OnEscapeEvent += HandleEscape;
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
