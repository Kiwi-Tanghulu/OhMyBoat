using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megalodon : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float threatRadius;
    [SerializeField] private float detectRadius;
    [SerializeField] private LayerMask shipLayer;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void DetectShip()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, detectRadius, shipLayer);

        if(cols.Length > 0 )
        {

        }
    }
}
