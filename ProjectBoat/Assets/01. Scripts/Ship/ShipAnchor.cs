using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAnchor : MonoBehaviour
{
    [SerializeField] private ShipInputSO inputSO;

    [SerializeField] private float activeDelay;
    
    private bool active = true;
    public bool Active => active;

    public GameObject CurrentObject => gameObject;

    public event Action<bool> OnActiveChange;

    private Coroutine activeCoroutine;

    private void Start()
    {
        inputSO.OnFEvent += ShipInputSO_OnFEvent;
    }

    private void OnDestroy()
    {
        inputSO.OnFEvent -= ShipInputSO_OnFEvent;
    }

    private void ToggleActive()
    {
        if(activeCoroutine == null)
            activeCoroutine = StartCoroutine(ToggleActiveDelay());
    }

    private IEnumerator ToggleActiveDelay()
    {
        yield return new WaitForSeconds(activeDelay);

        active = !active;
        
        OnActiveChange?.Invoke(active);

        activeCoroutine = null;
    }

    private void ShipInputSO_OnFEvent()
    {
        ToggleActive();
    }
}
