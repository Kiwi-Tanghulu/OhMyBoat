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
    [SerializeField] private CannonBall cannonBallPrefab;
    private CannonBall cannonBall;

    public UnityEvent<Transform> OnFire;

    private void Awake()
    {
        cannonBall = Instantiate(cannonBallPrefab, transform);
        cannonBall.gameObject.SetActive(false);
    }

    private void Start()
    {
        inputSO.OnSpaceEvetnt += Fire;
    }

    public void Fire()
    {
        cannonBall.transform.position = firePoint.position;
        cannonBall.Fire(transform.forward * firePower);

        OnFire?.Invoke(firePoint);
    }
}
