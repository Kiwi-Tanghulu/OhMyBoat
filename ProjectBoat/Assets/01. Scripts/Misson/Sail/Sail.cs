using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sail : MissonObject
{
    private Animator anim;

    private readonly int fixHash = Animator.StringToHash("Fix");
    private readonly int breakHash = Animator.StringToHash("Break");

    public override void InitMissonObject(Misson misson)
    {
        base.InitMissonObject(misson);

        anim = GetComponent<Animator>();
    }

    public override void StartMisson()
    {
        anim.SetTrigger(breakHash);
    }

    public override void EndMisson()
    {
        base.EndMisson();

        anim.SetTrigger(fixHash);
    }

    public override bool Interact(GameObject performer, bool actived, Vector3 point = default)
    {
        return true;
    }
}
