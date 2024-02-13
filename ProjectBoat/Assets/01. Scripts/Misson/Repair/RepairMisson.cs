using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RepairMisson : Misson
{
    [SerializeField] protected RepairMiniGame miniGame;

    public void StartMiniGame(RepairMissonObject missonObject)
    {
        miniGame.StartGame(missonObject);
    }
}
