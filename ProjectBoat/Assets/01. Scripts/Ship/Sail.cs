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

    private bool active;
    public bool Active => active;

    public Action<bool> OnActiveChange;

    private WindManager windManager;

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

        currentWindforce = windManager.Wind * currentWindCoefficient;
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
