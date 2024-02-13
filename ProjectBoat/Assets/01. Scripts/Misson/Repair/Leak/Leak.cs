using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Leak : RepairMissonObject
{
    protected bool isWorking;
    public bool IsWorking => isWorking;

    private ParticleSystem particle;

    public override void InitMissonObject(Misson misson)
    {
        base.InitMissonObject(misson);

        particle = GetComponent<ParticleSystem>();

        gameObject.SetActive(false);
        particle.Stop();
    }

    public override void StartMisson()
    {
        base.StartMisson();
        
        gameObject.SetActive(true);
        particle.Play();

        isWorking = true;
    }

    public override void EndMisson()
    {
        base.EndMisson();

        gameObject.SetActive(false);
        particle.Stop();

        isWorking = false;
    }
}
