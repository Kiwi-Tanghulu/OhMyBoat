using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuoyancyObject : MonoBehaviour
{
    public Transform[] floaters;
    public float underWaterDrag = 3f;
    public float underWaterAngularDrag = 1f;
    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;
    public float waterHeight;

    private Rigidbody rb;

    private bool underWater;

    private int floatersUnderWater;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        floatersUnderWater = 0;

        for (int i = 0; i < floaters.Length; i++)
        {
            float diff = floaters[i].position.y - waterHeight;

            if (diff < 0f)
            {
                floatersUnderWater++;

                rb.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(diff), floaters[i].position, ForceMode.Force);
                if (!underWater)
                {
                    underWater = true;
                    SwitchState(underWater);
                }
            }
        }

        if (underWater && floatersUnderWater == 0)
        {
            underWater = false;
            SwitchState(underWater);
        }
    }

    private void SwitchState(bool isUnderWater)
    {
        if(isUnderWater)
        {
            rb.drag = underWaterDrag;   
            rb.angularDrag = underWaterAngularDrag;
        }
        else
        {
            rb.drag = airDrag;
            rb.angularDrag = airAngularDrag;
        }
    }
}
