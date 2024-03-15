using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipKey : MonoBehaviour, IInteractable, IFocusable
{
    [SerializeField] private ShipInputSO inputSO;

    [Space]
    [SerializeField] private float keyRotateSpeed;

    [Space]
    [SerializeField] private float turnSpeed;
    [SerializeField] private float maxRotation;
    private float currentRotation = 0f;
    public float CurrentRotation => currentRotation;
    private float handlingDir;

    [Space]
    [SerializeField] private Transform rudderTrm;

    [Space]
    [SerializeField] private GameObject focusedVisual;

    public event Action<Vector3> OnKeyRotate;
    public event Action OnInteracted;

    public GameObject CurrentObject => gameObject;

    private void Start()
    {
        inputSO.OnMoveEvent += SetHandlingDir;
    }

    private void Update()
    {
        Handling();
    }

    private void OnDestroy()
    {
        inputSO.OnMoveEvent -= SetHandlingDir;
    }

    private void SetHandlingDir(Vector2 input)
    {
        handlingDir = new Vector2(input.x, 0f).normalized.x;
    }

    private void Handling()
    {
        currentRotation += handlingDir * turnSpeed * Time.deltaTime;

        if(currentRotation > maxRotation || currentRotation < -maxRotation)
        {
            currentRotation = Mathf.Clamp(currentRotation, -maxRotation, maxRotation);
        }
        else
        {
            transform.Rotate(new Vector3(0f, 0f, keyRotateSpeed * handlingDir * Time.deltaTime));

            Vector3 rotation = new Vector3(0f, currentRotation, 0f);
            rudderTrm.localRotation = Quaternion.Euler(rotation);
            OnKeyRotate?.Invoke(rotation);
        }
    }

    public bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        OnInteracted?.Invoke();

        return true;
    }

    public void OnFocusBegin(Vector3 point)
    {
        Debug.Log("focuesd key");
    }

    public void OnFocusEnd()
    {
        Debug.Log("focue end key");
    }
}
