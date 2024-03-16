using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDirection : MonoBehaviour
{
    private Transform directionTrm;
    private WindManager wind;

    private void Start()
    {
        wind = WindManager.Instance;
        directionTrm = transform.Find("Direction");
    }

    private void Update()
    {
        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(Vector3.forward, wind.Wind.normalized));

        directionTrm.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
