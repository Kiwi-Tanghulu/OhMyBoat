using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissonObject : MonoBehaviour, IInteractable, IFocusable
{
    protected Misson misson;
    [SerializeField] private Transform focusedVisual;

    public GameObject CurrentObject => gameObject;

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

    public void OnFocusBegin(Vector3 point)
    {
        focusedVisual.gameObject.SetActive(true);
    }

    public void OnFocusEnd()
    {
        focusedVisual.gameObject.SetActive(false);
    }
}
