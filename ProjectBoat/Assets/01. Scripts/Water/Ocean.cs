using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ocean : MonoBehaviour
{
    public static Ocean Instance { get; private set; }

    [SerializeField] private Transform ocean;

    //private float panSpeed;
    //private float normalTiling;
    //private float displaceStrength;
    //private Texture2D displacement;

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
        //panSpeed = oceanMat.GetFloat("_Pan_Speed");
        //normalTiling = oceanMat.GetFloat("_Normal_Tiling");
        //displaceStrength = oceanMat.GetFloat("_Displace_Strength");
        //displacement = (Texture2D)oceanMat.GetTexture("_Displacement");
    }

    public float GetWaterHeight(Vector3 position)
    {
        //Vector2 uv1 = Panners(position, new Vector2(0.1f, 1f), 2);
        //float r1 = displacement.GetPixelBilinear(uv1.x, uv1.y).r;

        //Vector2 uv2 = Panners(position, new Vector2(0.3f, -1f), 1);
        //float r2 = displacement.GetPixelBilinear(uv2.x, uv2.y).r;

        //Debug.Log(Mathf.Clamp01(r1 + r1) * displaceStrength);
        //return Mathf.Clamp01(r1 + r1) * displaceStrength;

        Vector2 uv = new Vector2(position.x, position.z) * waveIntensity + (Vector2.one * Time.time * waveSpeed);
        float r = noise.GetPixelBilinear(uv.x, uv.y).r;
        Vector3 mul = Vector3.up * r;

        return mul.y + ocean.position.y;
    }

    //private Vector2 Panners(Vector3 position, Vector2 direction, float tilingmultiplier)
    //{
    //    Vector2 uv = new Vector2(position.x, position.z);
    //    float tiling = normalTiling * tilingmultiplier;
    //    Vector2 offset = Time.time * direction * panSpeed;

    //    return new Vector2(position.x, position.z) * (normalTiling * tilingmultiplier) + (Time.time * direction * panSpeed);
    //}
}
