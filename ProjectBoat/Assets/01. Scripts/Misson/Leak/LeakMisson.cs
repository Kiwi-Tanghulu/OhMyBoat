using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakMisson : Misson
{
    [SerializeField] private LeakTransformSO leakTransformsSO;
    [SerializeField] private Leak leakPrefab;

    private List<Leak> leaks;
    private int workingLeakCount;

    protected override void Start()
    {
        base.Start();

        leaks = new List<Leak>();
        for (int i = 0; i < leakTransformsSO.LeakTransforms.Count; i++)
        {
            Leak leak = Instantiate(
                leakPrefab,
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
        int leakIndex;

        do
        {
            leakIndex = UnityEngine.Random.Range(0, leaks.Count);
        }
        while (leaks[leakIndex].IsWorking);

        leaks[leakIndex].StartMisson();

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
