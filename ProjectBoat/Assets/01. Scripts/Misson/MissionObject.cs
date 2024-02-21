using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissionObject : MonoBehaviour, IInteractable, IFocusable
{
    private Mission ownedMisson;
    public Mission OwnedMisson => ownedMisson;

    public bool IsWorking { get; private set; } = false;

    [SerializeField] private Transform focusedVisual;

    public GameObject CurrentObject => gameObject;

    public virtual void InitMissionObject(Mission misson)
    {
        ownedMisson = misson;
    }
    public abstract bool Interact(Component performer, bool actived, Vector3 point = default);
    public virtual void StartMission()
    {
        IsWorking = true;
    }

    public virtual void EndMission(bool isSuccess)
    {
        IsWorking = false;
        ownedMisson.EndMission(isSuccess);
    }

    public virtual void OnFocusBegin(Vector3 point)
    {
        focusedVisual.gameObject.SetActive(true);
    }

    public virtual void OnFocusEnd()
    {
        focusedVisual.gameObject.SetActive(false);
    }
}
