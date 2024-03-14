using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class WaterWave : MonoBehaviour
{
    public static WaterWave Instance { get; private set; }

    [SerializeField] private Transform ocean;
    private Material oceanMat;

    [Space]
    [SerializeField] private int samplingCount = 3;

    [Space]
    [SerializeField] private int waveCount = 4;

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

    public Vector3 GetWaveHeight(Vector3 pos)
    {
        Vector3 w1 = Vector3.zero;
        Vector3 w2 = Vector3.zero;
        Vector3 w3 = Vector3.zero;
        Vector3 w4 = Vector3.zero;

        w1 = GerstnerWave(waveA, pos);
        w1 = GerstnerWave(waveA, pos - w1);
        w1 = GerstnerWave(waveA, pos - w1);
        w1 = GerstnerWave(waveA, pos - w1);

        w2 = GerstnerWave(waveB, pos);
        w2 = GerstnerWave(waveB, pos - w2);
        w2 = GerstnerWave(waveB, pos - w2);
        w2 = GerstnerWave(waveB, pos - w2);

        w3 = GerstnerWave(waveC, pos);
        w3 = GerstnerWave(waveC, pos - w3);
        w3 = GerstnerWave(waveC, pos - w3);
        w3 = GerstnerWave(waveC, pos - w3);

        w4 = GerstnerWave(waveD, pos);
        w4 = GerstnerWave(waveD, pos - w4);
        w4 = GerstnerWave(waveD, pos - w4);
        w4 = GerstnerWave(waveD, pos - w4);

        return ((w1 + w2 + w3 + w4) / waveCount) + transform.position;
    }

   private Vector3 GerstnerWave(Vector4 wave, Vector3 p)
    {
        Vector3 pos = p;
        Vector3 diff = Vector3.zero;
        Vector3 result = Vector3.zero;

        float steepness = wave.z;
        float wavelength = wave.w;
        float k = 2 * Mathf.PI / wavelength;
        float c = Mathf.Sqrt(9.8f / k);
        Vector2 d = new Vector2(wave.x, wave.y).normalized;
        float f = k * (Vector2.Dot(d, new Vector2(pos.x, pos.z)) - c * Time.time);
        float a = steepness / k;

        result = new Vector3(
            d.x * (a * Mathf.Cos(f)),
            a * Mathf.Sin(f),
            d.y * (a * Mathf.Cos(f)));

        return result;
    }
}
