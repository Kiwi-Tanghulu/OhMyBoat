using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderMissionObject : RepairMissionObject
{
    private Animator animator;

    private readonly int fixHash = Animator.StringToHash("Fix");
    private readonly int breakHash = Animator.StringToHash("Break");

    public override void InitMissionObject(Mission misson)
    {
        base.InitMissionObject(misson);

        animator = GetComponent<Animator>();
    }

    public override void StartMission()
    {
        base.StartMission();

        animator.SetTrigger(breakHash);
    }

    public override void SuccessMission()
    {
        base.SuccessMission();

        animator.SetTrigger(fixHash);
    }

    public override void OnFocusBegin(Vector3 point)
    {
        if (!OwnedMisson.IsWorking)
            return;

        base.OnFocusBegin(point);
    }

    public override void OnFocusEnd()
    {
        if (!OwnedMisson.IsWorking)
            return;

        base.OnFocusEnd();
    }
}
