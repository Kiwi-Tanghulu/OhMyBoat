using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailMiniGame : RepairMiniGame
{
    [Space]
    [SerializeField] private Transform topSail;

    [Space]
    [SerializeField] private float initRotation;
    [SerializeField] private float increaseAmount;
    [SerializeField] private float decreaseAmount;
    [SerializeField] private float maxChangeValue;
    [SerializeField] private float minChangeValue;

    private float changeValue;
    Vector3 changeRotation;

    public override void StartGame(RepairMissonObject missonObject)
    {
        base.StartGame(missonObject);

        topSail.rotation = Quaternion.Euler(0, 0, initRotation);
    }

    protected override void Update()
    {
        base.Update();
        
        changeValue = Mathf.Clamp(changeValue, minChangeValue, maxChangeValue);
        if (topSail.eulerAngles.z - 360f < initRotation)
        {
            topSail.rotation = Quaternion.Euler(0, 0, initRotation);
            changeValue = Mathf.Max(0f, changeValue);
        }

        changeRotation = (Vector3.forward * changeValue * Time.deltaTime) + topSail.eulerAngles;
        topSail.rotation = Quaternion.Euler(changeRotation);

        if (topSail.eulerAngles.z >= 359.5f)
        {
            topSail.rotation = Quaternion.Euler(Vector3.zero);
            EndGame(true);
        }
    }

    private void FixedUpdate()
    {
        changeValue -= decreaseAmount;
    }

    protected override void Input_SpaceEvent()
    {
        changeValue += increaseAmount;
    }
}
