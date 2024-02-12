using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class SailMisson : Misson
{
    [SerializeField] private Sail sail;

    protected override void Start()
    {
        base.Start();

        sail.InitMissonObject(this);
    }

    public override bool CanStartMisson()
    {
        return !isWorking;
    }

    public override void StartMisson()
    {
        base.StartMisson();

        sail.StartMisson();
    }
}
