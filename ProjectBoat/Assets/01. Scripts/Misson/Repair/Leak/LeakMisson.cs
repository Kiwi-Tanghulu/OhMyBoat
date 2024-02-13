using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakMisson : RepairMisson
{
    [SerializeField] private LeakTransformSO leakTransformsSO;

    private List<MissonObject> leaks;
    private int workingLeakCount;

    protected override void Start()
    {
        MissonManager.Instance.RegistMisson(this);

        leaks = new List<MissonObject>();
        for (int i = 0; i < leakTransformsSO.LeakTransforms.Count; i++)
        {
            MissonObject leak = Instantiate(
                missonObject,
                leakTransformsSO.LeakTransforms[i].position,
                Quaternion.Euler(leakTransformsSO.LeakTransforms[i].rotation),
                transform);

            leak.InitMissonObject(this);

            leaks.Add(leak);
        }
    }

    public override bool CanStartMisson()
    {
        return workingLeakCount < leaks.Count;
    }

    public override void StartMisson()
    {
        List<MissonObject> canStartLeaks = leaks.FindAll(x => x.IsWorking == false);
        int leakIndex = UnityEngine.Random.Range(0, canStartLeaks.Count);

        canStartLeaks[leakIndex].StartMisson();

        workingLeakCount++;
        isWorking = true;

        OnStartMisson?.Invoke();
    }

    public override void EndMisson()
    {
        workingLeakCount--;

        if(workingLeakCount == 0)
            isWorking = false;

        OnEndMisson?.Invoke();
    }
}
