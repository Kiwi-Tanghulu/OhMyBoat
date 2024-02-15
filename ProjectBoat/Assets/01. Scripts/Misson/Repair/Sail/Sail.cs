using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sail : RepairMissonObject
{
    private Animator anim;

    private readonly int fixHash = Animator.StringToHash("Fix");
    private readonly int breakHash = Animator.StringToHash("Break");

    public override void InitMissonObject(Misson misson)
    {
        base.InitMissonObject(misson);

        anim = GetComponent<Animator>();
        Debug.Log(1);
    }

    public override void StartMisson()
    {
        base.StartMisson();

        anim.SetTrigger(breakHash);
    }

    public override void EndMisson()
    {
        base.EndMisson();
        
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
