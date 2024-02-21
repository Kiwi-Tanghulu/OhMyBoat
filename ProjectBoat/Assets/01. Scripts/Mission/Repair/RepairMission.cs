using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RepairMission : Mission
{
    [SerializeField] protected RepairMiniGame miniGame;

    public void StartMiniGame(RepairMissionObject missonObject)
    {
        miniGame.StartGame(missonObject);
    }
}
