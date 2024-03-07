using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private ShipInputSO inputSO;

    [Space]
    [SerializeField] private Transform keyTrm;
    [SerializeField] private float keyRotateSpeed;

    [Space]
    [SerializeField] private float turnSpeed;
    [SerializeField] private float maxRotation;
    private float currentRotation = 0f;
    public float CurrentRotation => currentRotation;

    private float handlingDir;

    public event Action<float> OnKeyRotate;

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

            OnKeyRotate?.Invoke(handlingDir);
        }
    }
}
