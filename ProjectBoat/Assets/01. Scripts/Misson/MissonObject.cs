using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissonObject : MonoBehaviour, IInteractable
{
    protected Misson misson;

    public virtual void InitMissonObject(Misson misson)
    {
        this.misson = misson;
    }
    public abstract bool Interact(GameObject performer, bool actived, Vector3 point = default);
    public abstract void StartMisson();
    public virtual void EndMisson()
    {
        misson.EndMisson();
    }
}
