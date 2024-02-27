using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ocean : MonoBehaviour
{
    public static Ocean Instance { get; private set; }

    [SerializeField] private Transform ocean;

    private float waveSpeed;
    private float waveIntensity;
    private Texture2D noise;

    private Material oceanMat;

    private void Awake()
    {
        Instance = this;

        oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;

        waveSpeed = oceanMat.GetFloat("_WaveSpeed");
        waveIntensity = oceanMat.GetFloat("_WaveIntensity");
        noise = (Texture2D)oceanMat.GetTexture("_Noise");
    }

    public float GetWaterHeight(Vector3 position)
    {
        Vector2 uv = new Vector2(position.x, position.z) * waveIntensity + (Vector2.one * Time.time * waveSpeed);
        float r = noise.GetPixelBilinear(uv.x, uv.y).r;
        Vector3 mul = Vector3.up * r;

        return mul.y + ocean.position.y;
    }
}
