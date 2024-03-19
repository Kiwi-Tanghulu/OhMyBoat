using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cannon : MonoBehaviour
{
    [SerializeField] private ShipInputSO inputSO;

    [Space]
    [SerializeField] private Transform firePoint;
    [SerializeField] private float firePower;
    [SerializeField] private float fireDelay;
    [SerializeField] private CannonBall cannonBallPrefab;
    private CannonBall cannonBall;
    private WaitForSeconds wfs;
    private bool canFire;

    public UnityEvent<Transform> OnFire;

    private void Awake()
    {
        cannonBall = Instantiate(cannonBallPrefab, transform);
        cannonBall.gameObject.SetActive(false);
        canFire = true;
        wfs = new WaitForSeconds(fireDelay);
    }

    private void Start()
    {
        inputSO.OnSpaceEvetnt += Fire;
    }

    public void Fire()
    {
        if (!canFire) return;

        cannonBall.transform.position = firePoint.position;
        cannonBall.Fire(transform.forward * firePower);

        OnFire?.Invoke(firePoint);
    }

    private IEnumerator FireDelay()
    {
        canFire = false;

        yield return wfs;

        canFire = true;
    }
}
