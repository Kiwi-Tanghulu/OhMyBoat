using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunsungTest : MonoBehaviour
{
    private void Update()
    {
        Vector3 pos = transform.position;
        float y = WaterManager.Instance.GetWaveHeight(pos);
        pos.y = y;

        transform.position = pos;
    }
}
