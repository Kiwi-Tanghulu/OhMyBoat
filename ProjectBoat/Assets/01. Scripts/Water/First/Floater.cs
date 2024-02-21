using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rb;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 1f;
    public float floaterCount = 1f;
    public float waterDrag = 0.99f;
    public float waterAngluarDrag = 0.5f;

    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);

        float waveHeight = Wave.Instance.GetWaveHeight(transform.position.x);
        //�η� (��� ���� * �߷� * ���� �е�) ���⼱ �׳� ������ ������ ��
        if(transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacementMultiplier * -rb.velocity * waterDrag * Time.deltaTime, ForceMode.VelocityChange);
            rb.AddTorque(displacementMultiplier * -rb.angularVelocity * waterAngluarDrag * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}
