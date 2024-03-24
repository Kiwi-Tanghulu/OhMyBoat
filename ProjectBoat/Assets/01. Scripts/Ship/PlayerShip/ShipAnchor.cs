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

    //private void Start()
    //{
    //    inputSO.OnFEvent += ShipInputSO_OnFEvent;
    //}

    //private void OnDestroy()
    //{
    //    inputSO.OnFEvent -= ShipInputSO_OnFEvent;
    //}

    public void SetActive(bool value, bool immediately = false)
    {
        if (activeCoroutine != null)
        {
            StopCoroutine(activeCoroutine);
            activeCoroutine = null;
        }

        if (immediately)
        {
            active = value;

            OnActiveChange?.Invoke(active);

            activeCoroutine = null;
        }
        else
        {
            activeCoroutine = StartCoroutine(ToggleActiveDelay(value));
        }
    }

    private IEnumerator ToggleActiveDelay(bool value)
    {
        yield return new WaitForSeconds(activeDelay);

        active = value;
        
        OnActiveChange?.Invoke(active);

        activeCoroutine = null;
    }

    private void ShipInputSO_OnFEvent()
    {
        SetActive(!active);
    }
}
