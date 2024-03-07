using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.WSA;

public class Sail : MonoBehaviour
{
    public SailType sailType;

    [SerializeField] private GameObject[] deactiveSailObjects;
    [SerializeField] private GameObject[] activeSailObjects;
    [SerializeField] private Transform[] sailAnchorTrms;

    [Space]
    [SerializeField] private float maxWindCoefficient;
    [SerializeField] private float windCoefficientIncreaseAmount;
    [SerializeField] private float windCoefficientDecreaseAmount;
    private float currentWindCoefficient;
    private Vector3 currentWindforce;
    public Vector3 CurrentWindForce => currentWindforce;
    private WindManager windManager;
    [SerializeField] private float currentRotate;

    private float directionConcordance;

    private bool active;
    public bool Active => active;

    public Action<bool> OnActiveChange;

    private void Start()
    {
        windManager = WindManager.Instance;

        SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetActive(!active);
        }

        if (active)
            Accel();
        else
            Deaccel();

        SetWindForce();
    }

    private void SetWindForce()
    {
        Vector3 forward = new Vector3(
            Mathf.Sin(Mathf.Deg2Rad * (currentRotate + transform.eulerAngles.y)),
            0f,
            Mathf.Cos(Mathf.Deg2Rad * (currentRotate + transform.eulerAngles.y)));
        
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
            currentWindforce = transform.forward * windManager.Wind.magnitude * currentWindCoefficient * directionConcordance;
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
        currentWindCoefficient -= windCoefficientDecreaseAmount * Time.deltaTime;

        if (currentWindCoefficient <= 0f)
            currentWindCoefficient = 0f;
    }

    private void SetActive(bool value)
    {
        active = value;

        OnActiveChange?.Invoke(active);

        for(int i = 0; i < activeSailObjects.Length; i++)
        {
            activeSailObjects[i].SetActive(active);
            deactiveSailObjects[i].SetActive(!active);
        }
    }
}
