using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class WaterWave : MonoBehaviour
{
    public static WaterWave Instance { get; private set; }

    [SerializeField] private Transform ocean;
    private Material oceanMat;

    private Vector4 waveA;
    private Vector4 waveB;
    private Vector4 waveC;
    private Vector4 waveD;

    private void Awake()
    {
        Instance = this;

        oceanMat = ocean.GetComponent<MeshRenderer>().material;

        waveA = oceanMat.GetVector("_WaveA");
        waveB = oceanMat.GetVector("_WaveB");
        waveC = oceanMat.GetVector("_WaveC");
        waveD = oceanMat.GetVector("_WaveD");
    }

    public float GetWaveHeight(Vector3 pos)
    {
        float y = 0;

        y += GenerateWave(waveA, pos).y;
        y += GenerateWave(waveB, pos).y;
        y += GenerateWave(waveC, pos).y;
        y += GenerateWave(waveD, pos).y;

        Debug.Log(y);

        return y * 100;
    }

    private Vector3 GenerateWave(Vector4 waveParam, Vector3 pos)
    {
        Vector2 d = new Vector2(waveParam.x, waveParam.y).normalized;
        float k = Mathf.PI * 2 * waveParam.w;
        float c = Mathf.Sqrt(9.8f / k);
        float f = Vector2.Dot(d, new Vector2(pos.x, pos.z).normalized) - (Time.time * c) * k;
        float a = waveParam.z / k;

        float x = Mathf.Cos(f) * a * d.x + pos.x;
        float y = Mathf.Sin(f) * a;
        float z = Mathf.Cos(f) * a * d.y + pos.x;

        return new Vector3(x, y, z);
    }
}
