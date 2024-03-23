using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class Interlocutor : MonoBehaviour, IInteractable
{
    [SerializeField] UIInputSO input = null;

    [Space(15f)]
    [SerializeField] CinemachineVirtualCamera focusedCam = null;
    [SerializeField] DialogContextSO rootContext = null;
    [SerializeField] string interlocutorName = "unknown";

    [Space(15f)]
    public UnityEvent OnDialogFinishedEvent = null;
    [SerializeField] List<ContextEventTable> contextEvents = null;

    private const int FOCUSED_PRIORITY = 20;
    private const int UNFOCUSED_PRIORITY = 1;

    private DialogPanel dialogPanel = null;
    private DialogContextSO currentContext = null;
    private bool printing = false;

    private void Awake()
    {
        dialogPanel = DEFINE.MainCanvas.Find("DialogPanel").GetComponent<DialogPanel>();

        input.OnDialogActionEvent += HandleDialogAction;
    }

    public bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        if(actived == false)
            return false;

        StartDialog(rootContext);
        return true;
    }

	public void StartDialog(DialogContextSO rootContext)
    {
        contextEvents.ForEach(i => i?.Subscribe());

        dialogPanel.Display(true);
        focusedCam.Priority = FOCUSED_PRIORITY;

        SetContext(rootContext);
        InputManager.ChangeInputMap(InputMapType.UI);
    }

    public void FinishDialog()
    {
        contextEvents.ForEach(i => i?.Release());

        dialogPanel.Display(false);
        focusedCam.Priority = UNFOCUSED_PRIORITY;

        dialogPanel.Release();
        InputManager.ChangeInputMap(InputMapType.Play);

        OnDialogFinishedEvent?.Invoke();
    }

    private void SetContext(DialogContextSO context)
    {
        currentContext = context;
        printing = true;
        dialogPanel.SetContext(currentContext, interlocutorName, FinishDialogCallback);

        currentContext.OnContextStartEvent?.Invoke();
    }

    private void FinishDialogCallback()
    {
        printing = false;
        currentContext.OnContextFinishEvent?.Invoke();
    }

    private void HandleDialogAction()
    {
        if(printing)
            return;

        DialogContextSO nextContext = currentContext.NextContext;
        if(nextContext == null)
            FinishDialog();
        else
            SetContext(nextContext);
    }
}
