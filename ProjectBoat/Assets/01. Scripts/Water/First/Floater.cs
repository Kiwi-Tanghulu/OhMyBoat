using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Ocean.Instance.GetWaterHeight(transform.position), transform.position.z);
    }
}
