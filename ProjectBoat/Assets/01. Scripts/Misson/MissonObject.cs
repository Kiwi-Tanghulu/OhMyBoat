using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissonObject : MonoBehaviour, IInteractable, IFocusable
{
    private Misson ownedMisson;
    public Misson OwnedMisson => ownedMisson;

    public bool IsWorking { get; private set; } = false;

    [SerializeField] private Transform focusedVisual;

    public GameObject CurrentObject => gameObject;

    public virtual void InitMissonObject(Misson misson)
    {
        ownedMisson = misson;
    }
    public abstract bool Interact(Component performer, bool actived, Vector3 point = default);
    public virtual void StartMisson()
    {
        IsWorking = true;
    }

    public virtual void EndMisson()
    {
        IsWorking = false;
        ownedMisson.EndMisson();
    }

    public virtual void OnFocusBegin(Vector3 point)
    {
        focusedVisual.gameObject.SetActive(true);
    }

    public virtual void OnFocusEnd()
    {
        focusedVisual.gameObject.SetActive(false);
    }
}
