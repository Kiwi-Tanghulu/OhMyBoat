using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class SailMission : RepairMission
{
    public override bool CanStartMission()
    {
        return !isWorking;
    }

    public override void StartMission()
    {
        base.StartMission();
        
        missonObject.StartMission();
    }
}
