using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mission : MonoBehaviour
{
    public Action OnStartMisson;
    public Action<bool> OnEndMisson;

    public MissionType missonType;

    [SerializeField] protected MissionObject missonObject;

    protected bool isWorking;
    public bool IsWorking => isWorking;

    protected virtual void Start()
    {
        MissionManager.Instance.RegistMission(this);
        missonObject.InitMissionObject(this);
    }
    
    public virtual bool CanStartMission()
    {
        return !isWorking;
    }

    public virtual void StartMission()
    {
        isWorking = true;

        missonObject.StartMission();

        OnStartMisson?.Invoke();
    }

    public virtual void EndMission(bool isSuccess)
    {
        isWorking = false;

        OnEndMisson?.Invoke(isSuccess);

        MissionManager.Instance.EndMission(this, isSuccess);
    }
}
