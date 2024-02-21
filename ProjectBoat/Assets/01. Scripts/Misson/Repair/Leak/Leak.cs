using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Leak : RepairMissionObject
{
    private ParticleSystem particle;

    public override void InitMissionObject(Mission misson)
    {
        base.InitMissionObject(misson);

        particle = GetComponent<ParticleSystem>();

        gameObject.SetActive(false);
        particle.Stop();
    }

    public override void StartMission()
    {
        base.StartMission();
        
        gameObject.SetActive(true);
        particle.Play();
    }

    public override void EndMission(bool isSuccess)
    {
        base.EndMission(isSuccess);

        gameObject.SetActive(false);
        particle.Stop();
    }
}
