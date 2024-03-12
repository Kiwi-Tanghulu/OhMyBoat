using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public struct BuoyancyPoint
{
    public Vector3 velocity;
    public bool inWater;
}

public class Buoyancy : MonoBehaviour
{
    public float floatingPower;
    public float maxFloatingPower;
    public float gravityPower;
    public Vector2 airDrag;
    public Vector2 waterDrag;
    public Transform[] floatingPoints;
    private BuoyancyPoint[] buoyancies;

    public Transform debugObject;
    
    private Rigidbody rb;

    private float diff;
    private float unitFloatingPower;
    private float unitGravityPower;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        buoyancies = new BuoyancyPoint[floatingPoints.Length];
        for (int i = 0; i <  floatingPoints.Length; i++)
        {
            buoyancies[i] = new BuoyancyPoint();
            buoyancies[i].velocity = Vector3.zero;
            buoyancies[i].inWater = false;
        }

        unitFloatingPower = floatingPower / floatingPoints.Length;
        unitGravityPower = gravityPower / floatingPoints.Length;
    }

    private void Update()
    {
        for (int i = 0; i < buoyancies.Length; i++)
        {
            #region
            //if (floatingPoints[i].position.y < WaterWave.Instance.GetWaveHeight(floatingPoints[i].position))
            //{
            //    rb.drag = waterDrag.x;
            //    rb.angularDrag = waterDrag.y;

            //    diff = WaterWave.Instance.GetWaveHeight(floatingPoints[i].position) - floatingPoints[i].position.y;

            //    if (!buoyancies[i].inWater)
            //    {
            //        buoyancies[i].velocity *= 0.75f;
            //        rb.velocity *= 0.75f;
            //        buoyancies[i].inWater = true;
            //    }

            //    buoyancies[i].velocity += Vector3.up * unitFloatingPower * Mathf.Min(Mathf.Abs(diff), 1) * Time.deltaTime;
            //    buoyancies[i].velocity.y = Mathf.Min(buoyancies[i].velocity.y, maxFloatingPower);

            //    rb.AddForceAtPosition(buoyancies[i].velocity, floatingPoints[i].position, ForceMode.Acceleration);
            //}
            //else
            //{
            //    rb.drag = airDrag.x;
            //    rb.angularDrag = airDrag.y;

            //    if (buoyancies[i].inWater)
            //    {
            //        buoyancies[i].velocity *= 0.1f;
            //        rb.velocity *= 0.1f;
            //        buoyancies[i].inWater = false;
            //    }

            //    buoyancies[i].velocity += Vector3.up * unitGravityPower * Time.deltaTime;

            //    rb.AddForceAtPosition(buoyancies[i].velocity, floatingPoints[i].position, ForceMode.Acceleration);
            //}
            #endregion

            Vector3 waterHeight = WaterWave.Instance.GetWaveHeight(Vector3.zero);
            debugObject.position = new Vector3(debugObject.position.x, waterHeight.y, debugObject.position.z);

            if (waterHeight.y > floatingPoints[i].position.y)
            {
                rb.drag = waterDrag.x;
                rb.angularDrag = waterDrag.y;

                //rb.AddForceAtPosition(buoyancies[i].velocity, floatingPoints[i].position, ForceMode.Acceleration);
                rb.AddForceAtPosition(Vector3.up * unitFloatingPower, floatingPoints[i].position, ForceMode.Acceleration);
            }
            else
            {
                rb.drag = airDrag.x;
                rb.angularDrag = airDrag.y;

                //rb.AddForceAtPosition(buoyancies[i].velocity, floatingPoints[i].position, ForceMode.Acceleration);
                rb.AddForceAtPosition(Vector3.up * unitGravityPower, floatingPoints[i].position, ForceMode.Acceleration);
            }
        }
    }
}
