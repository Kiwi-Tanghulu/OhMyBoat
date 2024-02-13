using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Misson : MonoBehaviour
{
    public Action OnStartMisson;
    public Action OnEndMisson;

    [SerializeField] protected MissonObject missonObject;

    protected bool isWorking;
    public bool IsWorking => isWorking;

    protected virtual void Start()
    {
        MissonManager.Instance.RegistMisson(this);
        missonObject.InitMissonObject(this);
    }
    
    public abstract bool CanStartMisson();
    public virtual void StartMisson()
    {
        OnStartMisson?.Invoke();
        isWorking = true;
    }
    public virtual void EndMisson()
    {
        OnEndMisson?.Invoke();
        isWorking = false;
    }
}
