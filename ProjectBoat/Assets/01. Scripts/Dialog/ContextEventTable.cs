using UnityEngine.Events;

[System.Serializable]
public class ContextEventTable
{
	public DialogContextSO EventContext;
    public UnityEvent OnContextStartEvent;
    public UnityEvent OnContextFinishEvent;

    public void Subscribe()
    {
        EventContext.OnContextFinishEvent += FinishEvent;
        EventContext.OnContextStartEvent += StartEvent;
    }

    public void Release()
    {
        EventContext.OnContextFinishEvent -= FinishEvent;
        EventContext.OnContextStartEvent -= StartEvent;
    }

    private void FinishEvent()
    {
        OnContextFinishEvent?.Invoke();
    }

    private void StartEvent()
    {
        OnContextFinishEvent?.Invoke();
    }
}
