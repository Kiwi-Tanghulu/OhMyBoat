using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakMission : RepairMission
{
    [SerializeField] private LeakTransformSO leakTransformsSO;

    private List<MissionObject> leaks;
    private int workingLeakCount;

    protected override void Start()
    {
        MissionManager.Instance.RegistMission(this);

        leaks = new List<MissionObject>();
        for (int i = 0; i < leakTransformsSO.LeakTransforms.Count; i++)
        {
            MissionObject leak = Instantiate(
                missonObject,
                leakTransformsSO.LeakTransforms[i].position,
                Quaternion.Euler(leakTransformsSO.LeakTransforms[i].rotation),
                transform);

            leak.InitMissionObject(this);

            leaks.Add(leak);
        }

        missionInterval = UnityEngine.Random.Range(minMissionInterval, maxMissionInterval);
        currentInterval = 0;
    }

    protected override void Update()
    {
        if (workingLeakCount < leaks.Count)
        {
            currentInterval += Time.deltaTime;
        }
    }

    public override bool CanStartMission()
    {
        return workingLeakCount < leaks.Count && currentInterval > missionInterval;
    }

    public override void StartMission()
    {
        List<MissionObject> canStartLeaks = leaks.FindAll(x => x.IsWorking == false);
        int leakIndex = UnityEngine.Random.Range(0, canStartLeaks.Count);

        workingLeakCount++;

        canStartLeaks[leakIndex].StartMission();

        isWorking = true;

        OnStartMisson?.Invoke();

        missionInterval = UnityEngine.Random.Range(minMissionInterval, maxMissionInterval);
        currentInterval = 0;
    }

    public override void SuccessMission()
    {
        workingLeakCount--;

        if (workingLeakCount == 0)
            isWorking = false;
    }
}
