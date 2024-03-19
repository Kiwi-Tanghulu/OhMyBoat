using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    [SerializeField] private Transform shipTrm;

    private Transform arrowTrm;

    private void Awake()
    {
        arrowTrm = transform.Find("CompassArrow");
    }

    private void Update()
    {
        arrowTrm.rotation = Quaternion.Euler(new Vector3(0f, 0f, -shipTrm.eulerAngles.y));
    }
}
