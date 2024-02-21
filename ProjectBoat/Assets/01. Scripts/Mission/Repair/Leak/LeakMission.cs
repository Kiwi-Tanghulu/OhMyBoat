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
    }

    public override bool CanStartMission()
    {
        return workingLeakCount < leaks.Count;
    }

    public override void StartMission()
    {
        List<MissionObject> canStartLeaks = leaks.FindAll(x => x.IsWorking == false);
        int leakIndex = UnityEngine.Random.Range(0, canStartLeaks.Count);

        canStartLeaks[leakIndex].StartMission();

        workingLeakCount++;

        isWorking = true;

        OnStartMisson?.Invoke();
    }

    public override void EndMission(bool isSuccess)
    {
        workingLeakCount--;

        if(workingLeakCount == 0)
            isWorking = false;

        OnEndMisson?.Invoke(isSuccess);

        MissionManager.Instance.EndMission(this, isSuccess);
    }
}
