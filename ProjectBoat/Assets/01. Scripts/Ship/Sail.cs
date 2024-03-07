using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Sail : MonoBehaviour
{
    public SailType sailType;

    [Space]
    [SerializeField] private float maxWindCoefficient;
    [SerializeField] private float windCoefficientIncreaseAmount;
    [SerializeField] private float windCoefficientDecreaseAmount;
    private float currentWindCoefficient;
    private Vector3 currentWindforce;
    public Vector3 CurrentWindForce => currentWindforce;
    private WindManager windManager;

    private float currentRotate;
    private float directionConcordance;

    private bool active;
    public bool Active => active;

    public Action<bool> OnActiveChange;

    private void Start()
    {
        windManager = WindManager.Instance;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ToggleActive();
        }

        if (active)
            Accel();
        else
            Deaccel();

        SetWindForce();
    }

    private void SetWindForce()
    {
        Vector3 forward = Quaternion.Euler(0f, 0f, currentRotate) * Vector3.forward;
        float angle = 0f;

        angle = Vector3.Angle(forward, windManager.Wind.normalized);

        if (angle > 90f)
            angle = Vector3.Angle(-forward, windManager.Wind.normalized);

        directionConcordance = -(angle / 90f - 1f);

        if (sailType == SailType.Horizontal)
        {
            currentWindforce = windManager.Wind * currentWindCoefficient * directionConcordance;
        }
        else
        {
            currentWindforce = forward * windManager.Wind.magnitude * currentWindCoefficient * directionConcordance;
        }
    }

    private void Accel()
    {
        if (currentWindCoefficient >= maxWindCoefficient)
        {
            currentWindCoefficient = maxWindCoefficient;
            return;
        }

        currentWindCoefficient += windCoefficientIncreaseAmount * Time.deltaTime;
    }

    private void Deaccel()
    {
        if (currentWindCoefficient <= 0f)
        {
            currentWindCoefficient = 0f;
            return;
        }

        currentWindCoefficient += windCoefficientDecreaseAmount * Time.deltaTime;
    }

    private void ToggleActive()
    {
        active = !active;

        OnActiveChange?.Invoke(active);
    }
}
