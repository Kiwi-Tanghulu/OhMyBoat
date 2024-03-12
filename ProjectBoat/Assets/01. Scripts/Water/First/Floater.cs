//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Floater : MonoBehaviour
//{
//    public Transform[] floaters;
//    public float underWaterDrag = 3f;
//    public float underWaterAngularDrag = 1f;
//    public float airDrag = 0f;
//    public float airAngularDrag = 0.05f;
//    public float floatingPower = 15f;
//    public float gravity = -9.81f;

//    private Rigidbody rb;
//    private bool isUnderWater;
//    private int floatersUnderWater;
//    private float addPower = 0f;

//    private void Awake()
//    {
//        rb = GetComponent<Rigidbody>();

//    }

//    private void FixedUpdate()
//    {
//        floatersUnderWater = 0;
//        addPower = 0;

//        for (int i = 0; i < floaters.Length; i++)
//        {
//            //float diff = floaters[i].position.y - WaterWave.Instance.GetWaveHeight(floaters[i].position);

//            addPower += gravity / floaters.Length * Time.fixedDeltaTime;

//            if (diff < 0f)
//            {
//                floatersUnderWater++;

//                addPower += floatingPower * Mathf.Abs(diff) / floaters.Length;

//                if (!isUnderWater)
//                {
//                    isUnderWater = true;
//                    SwitchState(isUnderWater);
//                }
//            }

//            rb.AddForceAtPosition(Vector3.up * addPower, floaters[i].position, ForceMode.Acceleration);
//        }

//        if (isUnderWater && floatersUnderWater == 0)
//        {
//            isUnderWater = false;
//            SwitchState(isUnderWater);
//        }
//    }

//    private void SwitchState(bool isUnderWater)
//    {
//        if (isUnderWater)
//        {
//            rb.drag = underWaterDrag;
//            rb.angularDrag = underWaterAngularDrag;
//        }
//        else
//        {
//            rb.drag = airDrag;
//            rb.angularDrag = airAngularDrag;
//        }
//    }
//}
