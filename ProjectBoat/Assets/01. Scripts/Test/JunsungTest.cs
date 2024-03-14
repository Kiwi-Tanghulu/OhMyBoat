using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunsungTest : MonoBehaviour
{
    private void Update()
    {
        Vector3 pos = transform.position;
        float y = WaterWave.Instance.GetWaveHeight(pos).y;
        pos.y = y;

        transform.position = pos;
    }
}
