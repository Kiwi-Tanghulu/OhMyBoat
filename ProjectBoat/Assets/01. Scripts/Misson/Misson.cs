using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Misson : MonoBehaviour
{
    protected virtual void Start()
    {
        MissonManager.Instance.RegistMisson(this);
    }

    public abstract bool IsWorking();
    public abstract bool CanMakeMisson();
    public abstract void MakeMisson();
}
