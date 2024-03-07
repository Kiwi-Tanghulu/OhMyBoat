using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    [SerializeField] private ShipInputSO inputSO;

    [SerializeField] private float activeDelay;
    
    private bool active = true;
    public bool Active => active;

    public Action<bool> OnActiveChange;

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
        StartCoroutine(ToggleActiveDelay());
    }

    private IEnumerator ToggleActiveDelay()
    {
        yield return new WaitForSeconds(activeDelay);

        active = !active;
        
        OnActiveChange?.Invoke(active);
    }

    private void ShipInputSO_OnFEvent()
    {
        ToggleActive();
    }
}
