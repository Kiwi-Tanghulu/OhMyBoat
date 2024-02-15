using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RepairMiniGame : MonoBehaviour
{
    [SerializeField] private MiniGameInputSO inputSO;

    [Space]
    [SerializeField] private protected float gameTime = 5f;
    protected float currentGameTime;

    private RepairMissonObject missonObject;

    public virtual void StartGame(RepairMissonObject missonObject)
    {
        this.missonObject = missonObject;
        currentGameTime = 0;
        
        inputSO.OnSpaceEvent += Input_SpaceEvent;
        InputManager.ChangeInputMap(InputMapType.MiniGame);

        gameObject.SetActive(true);
    }

    protected virtual void Update()
    {
        currentGameTime += Time.deltaTime;

        if (currentGameTime >= gameTime)
        {
            EndGame(false);
        }
    }

    public virtual void EndGame(bool result)
    {
        inputSO.OnSpaceEvent -= Input_SpaceEvent;
        InputManager.ChangeInputMap(InputMapType.Play);

        if(result)
        {
            missonObject.EndMisson();
        }
        else
        {
            missonObject.ResetMisson();
        }
        
        missonObject = null;

        gameObject.SetActive(false);
    }

    protected abstract void Input_SpaceEvent();
}