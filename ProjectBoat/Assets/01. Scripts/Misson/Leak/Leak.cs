using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak : MissonObject
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

    public override bool Interact(GameObject performer, bool actived, Vector3 point = default)
    {
        Debug.Log("leak misson interact");

        return true;
    }

    public override void StartMisson()
    {
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
