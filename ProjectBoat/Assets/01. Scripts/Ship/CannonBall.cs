using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private float deactiveTime;
    private Coroutine deactiveCo;
    private WaitForSeconds wfs;

    private Rigidbody rb;

    private void Awake()
    {
        wfs = new WaitForSeconds(deactiveTime);
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.forward = rb.velocity.normalized;
    }

    public void Fire(Vector3 fireVector)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(fireVector, ForceMode.Impulse);
        gameObject.SetActive(true);

        if(deactiveCo != null)
            StopCoroutine(deactiveCo);
        deactiveCo = StartCoroutine(DeactiveCo());
    }

    private IEnumerator DeactiveCo()
    {
        yield return wfs;

        gameObject.SetActive(false);
    }
}
