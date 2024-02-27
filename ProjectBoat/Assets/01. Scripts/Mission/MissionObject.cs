using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class MissionObject : MonoBehaviour, IInteractable, IFocusable
{
    public Action<Component> OnInteracted;

    private Mission ownedMisson;
    public Mission OwnedMisson => ownedMisson;

    protected bool isWorking;
    public bool IsWorking => isWorking;

    [SerializeField] private Transform focusedVisual;

    public GameObject CurrentObject => gameObject;

    public event Action<Vector3> OnFocused;
    public event Action OnDefocused;

    public virtual void InitMissionObject(Mission misson)
    {
        ownedMisson = misson;
    }

    public virtual bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        if(actived)
            OnInteracted?.Invoke(performer);

        return actived;
    }

    public virtual void StartMission()
    {
        isWorking = true;
    }

    public virtual void EndMission(bool isSuccess)
    {
        if (isSuccess)
            SuccessMission();
        else
            FailureMission();

        ownedMisson.EndMission(isSuccess);
    }

    public virtual void SuccessMission()
    {
        isWorking = false;
    }

    public virtual void FailureMission()
    {
        isWorking = true;
    }

    public virtual void OnFocusBegin(Vector3 point)
    {
        focusedVisual.gameObject.SetActive(true);
        OnFocused?.Invoke(point);
    }

    public virtual void OnFocusEnd()
    {
        focusedVisual.gameObject.SetActive(false);
        OnDefocused?.Invoke();
    }
}
