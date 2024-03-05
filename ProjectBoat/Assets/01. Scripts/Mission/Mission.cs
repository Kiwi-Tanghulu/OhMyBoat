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

    [SerializeField] protected float minMissionInterval;
    [SerializeField] protected float maxMissionInterval;
    protected float missionInterval;
    protected float currentInterval;

    protected virtual void Start()
    {
        MissionManager.Instance.RegistMission(this);
        missonObject.InitMissionObject(this);

        missionInterval = UnityEngine.Random.Range(minMissionInterval, maxMissionInterval);
        currentInterval = 0;
    }

    protected virtual void Update()
    {
        if(!isWorking)
        {
            currentInterval += Time.deltaTime;
        }
    }

    public virtual bool CanStartMission()
    {
        return !isWorking && currentInterval >= missionInterval;
    }

    public virtual void StartMission()
    {
        isWorking = true;

        missonObject.StartMission();

        OnStartMisson?.Invoke();

        missionInterval = UnityEngine.Random.Range(minMissionInterval, maxMissionInterval);
        currentInterval = 0;
    }

    public virtual void EndMission(bool isSuccess)
    {
        if (isSuccess)
            SuccessMission();
        else
            FailureMission();

        OnEndMisson?.Invoke(isSuccess);

        MissionManager.Instance.EndMission(this, isSuccess);
    }

    public virtual void SuccessMission()
    {
        isWorking = false;
    }

    public virtual void FailureMission()
    {
        isWorking = true;
    }
}
