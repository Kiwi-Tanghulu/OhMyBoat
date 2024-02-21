using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mission : MonoBehaviour
{
    public event Action OnStartMisson;
    public event Action<bool> OnEndMisson;

    public MissionType missonType;

    [SerializeField] protected MissionObject missonObject;

    protected bool isWorking;
    public bool IsWorking => isWorking;

    protected virtual void Start()
    {
        MissionManager.Instance.RegistMission(this);
        missonObject.InitMissionObject(this);
    }
    
    public abstract bool CanStartMission();
    public virtual void StartMission()
    {
        OnStartMisson?.Invoke();
        isWorking = true;
    }
    public virtual void EndMission(bool isSuccess)
    {
        OnEndMisson?.Invoke(isSuccess);
        isWorking = false;

        MissionManager.Instance.EndMission(this);
    }
}
