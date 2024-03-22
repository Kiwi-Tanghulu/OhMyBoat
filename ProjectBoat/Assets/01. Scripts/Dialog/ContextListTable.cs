using UnityEngine.Events;

[System.Serializable]
public struct ContextListTable
{
	public DialogContextSO DialogContext;
    public UnityEvent OnContextFinishedEvent;
}
