using Cinemachine;
using UnityEngine;

public class Interlocutor : MonoBehaviour
{
    [SerializeField] UIInputSO input = null;

    [Space(15f)]
    [SerializeField] CinemachineVirtualCamera focusedCam = null;
    [SerializeField] DialogContextSO rootContext = null;
    [SerializeField] string interlocutorName = "unknown";

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

    private void Start()
    {
        StartDialog(rootContext);
    }

	public void StartDialog(DialogContextSO rootContext)
    {
        dialogPanel.Display(true);
        SetContext(rootContext);
        InputManager.ChangeInputMap(InputMapType.UI);
    }

    public void FinishDialog()
    {
        dialogPanel.Display(false);
        dialogPanel.Release();
        InputManager.ChangeInputMap(InputMapType.Play);
    }

    private void SetContext(DialogContextSO context)
    {
        currentContext = context;
        printing = true;
        dialogPanel.SetContext(currentContext, interlocutorName, FinishDialogCallback);
    }

    private void FinishDialogCallback()
    {
        printing = false;
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
