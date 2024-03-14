using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//[Serializable]
//public struct BuoyancyPoint
//{
//    public Vector3 velocity;
//    public bool inWater;
//}

//[RequireComponent(typeof(Rigidbody))]
public class Buoyancy : MonoBehaviour
{
    [SerializeField] private float floatingPower;

    [Space]
    [SerializeField] private Transform frontFloatingPoint;
    [SerializeField] private Transform backFloatingPoint;
    [SerializeField] private Transform leftFloatingPoint;
    [SerializeField] private Transform rightFloatingPoint;
    [SerializeField] private float floatingOffset;

    //public float maxFloatingPower;
    //public float gravityPower;
    //public Vector2 airDrag;
    //public Vector2 waterDrag;
    //public Transform[] floatingPoints;
    //private BuoyancyPoint[] buoyancies;

    //public Transform debugObject;

    //private Rigidbody rb;

    //private float diff;
    //private float unitFloatingPower;
    //private float unitGravityPower;



    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //buoyancies = new BuoyancyPoint[floatingPoints.Length];
        //for (int i = 0; i <  floatingPoints.Length; i++)
        //{
        //    buoyancies[i] = new BuoyancyPoint();
        //    buoyancies[i].velocity = Vector3.zero;
        //    buoyancies[i].inWater = false;
        //}

        //unitFloatingPower = floatingPower / floatingPoints.Length;
        //unitGravityPower = gravityPower / floatingPoints.Length;
    }

    private void Update()
    {
        #region floating by rigidbody
        //for (int i = 0; i < buoyancies.Length; i++)
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

            //Vector3 waterHeight = WaterWave.Instance.GetWaveHeight(floatingPoints[i].position);
            //debugObject.position = new Vector3(debugObject.position.x, waterHeight.y, debugObject.position.z);

            //if (waterHeight.y > floatingPoints[i].position.y)
            //{
            //    rb.drag = waterDrag.x;
            //    rb.angularDrag = waterDrag.y;

            //    rb.AddForceAtPosition(Vector3.up * unitFloatingPower, floatingPoints[i].position, ForceMode.Acceleration);
            //}
            //else
            //{
            //    rb.drag = airDrag.x;
            //    rb.angularDrag = airDrag.y;

            //    rb.AddForceAtPosition(Vector3.up * unitGravityPower, floatingPoints[i].position, ForceMode.Acceleration);
            //}
        }
        #endregion

        //position
        float waterHeight = WaterWave.Instance.GetWaveHeight(transform.position).y + floatingOffset;
        float y = Mathf.Lerp(waterHeight, transform.position.y, Time.deltaTime * floatingPower);
        Vector3 pos = transform.position;
        Vector3 angle = transform.eulerAngles;

        pos.y = y;
        transform.position = pos;

        //x rotation
        Vector3 frontVector = new Vector3(frontFloatingPoint.position.x, WaterWave.Instance.GetWaveHeight(frontFloatingPoint.position).y, frontFloatingPoint.position.z);
        Vector3 backVector = new Vector3(backFloatingPoint.position.x, WaterWave.Instance.GetWaveHeight(backFloatingPoint.position).y, backFloatingPoint.position.z);
        Vector3 forwardVector = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
        Vector3 hypotenuse = (frontVector - backVector).normalized;
        float dot = Mathf.Abs(Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(hypotenuse, forwardVector)));
        angle.x = frontVector.y < backVector.y ? dot : -dot;

        //z rotation
        Vector3 leftVector = new Vector3(leftFloatingPoint.position.x, WaterWave.Instance.GetWaveHeight(leftFloatingPoint.position).y, leftFloatingPoint.position.z);
        Vector3 rightVector = new Vector3(rightFloatingPoint.position.x, WaterWave.Instance.GetWaveHeight(rightFloatingPoint.position).y, rightFloatingPoint.position.z);
        Vector3 rightDir = new Vector3(transform.right.x, 0f, transform.right.z).normalized;
        hypotenuse = (rightVector - leftVector).normalized;
        dot = Mathf.Abs(Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(hypotenuse, rightDir)));
        angle.z = leftVector.y < rightVector.y ? dot : -dot;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angle), Time.deltaTime * floatingPower);
    }
}