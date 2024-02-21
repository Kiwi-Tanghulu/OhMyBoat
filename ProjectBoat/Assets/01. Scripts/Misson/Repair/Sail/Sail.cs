using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sail : RepairMissionObject
{
    private Animator anim;

    private readonly int fixHash = Animator.StringToHash("Fix");
    private readonly int breakHash = Animator.StringToHash("Break");

    public override void InitMissionObject(Mission misson)
    {
        base.InitMissionObject(misson);

        anim = GetComponent<Animator>();
        Debug.Log(1);
    }

    public override void StartMission()
    {
        base.StartMission();

        anim.SetTrigger(breakHash);
    }

    public override void EndMission(bool isSuccess)
    {
        base.EndMission(isSuccess);
        
        anim.SetTrigger(fixHash);
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
