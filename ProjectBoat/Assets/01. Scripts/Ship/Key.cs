using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private ShipInputSO inputSO;

    [Space]
    [SerializeField] private float turnCoefficient;
    [SerializeField] private float maxRotation;
    [SerializeField] private float currentRotation = 0f;

    public float CurrentRotate => currentRotation;

    private float handlingDir;

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
        currentRotation += handlingDir * turnCoefficient * Time.deltaTime;
        currentRotation = Mathf.Clamp(currentRotation, -maxRotation, maxRotation);
    }
}
