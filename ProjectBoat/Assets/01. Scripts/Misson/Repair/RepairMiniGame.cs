using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RepairMiniGame : MonoBehaviour
{
    private RepairMissonObject missonObject;

    private bool isSuccesses;

    public virtual void StartGame(RepairMissonObject missonObject)
    {
        this.missonObject = missonObject;
        InputManager.ChangeInputMap(InputMapType.MiniGame);
        Debug.Log("start minigame");
    }

    public virtual void EndGame()
    {
        if(isSuccesses)
        {
            missonObject.EndMisson();
        }
        else
        {
            missonObject.ResetMisson();
        }
        
        missonObject = null;
        isSuccesses = false;
        InputManager.ChangeInputMap(InputMapType.Play);
    }
}