using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class SailMisson : RepairMisson
{
    public override bool CanStartMisson()
    {
        return !isWorking;
    }

    public override void StartMisson()
    {
        base.StartMisson();
        
        missonObject.StartMisson();
    }
}
