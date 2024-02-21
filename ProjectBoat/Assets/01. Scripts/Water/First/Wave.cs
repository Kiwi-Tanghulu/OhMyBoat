using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public static Wave Instance { get; private set; }

    public float amplitude;
    public float length;
    public float speed;
    public float offset;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;
    }

    //x위치의 파도 높이
    public float GetWaveHeight(float x)
    {
        return amplitude * Mathf.Sin(x / length + offset);
    }
}
