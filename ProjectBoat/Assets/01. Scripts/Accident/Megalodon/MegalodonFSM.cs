using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegalodonFSM : MonoBehaviour
{
    public StateMachine<MegalodonFSM, MegalodonStateType> stateMachine;

    [SerializeField] private MegalodonStateInfoSO stateInfo;
    public MegalodonStateInfoSO StateInfo => stateInfo;

    public MegalodonMovement Movement { get; private set; }

    public Ship targetShip { get; private set; }

    private void Start()
    {
        targetShip = Ship.Instance;
        Movement = GetComponent<MegalodonMovement>();

        stateMachine = new StateMachine<MegalodonFSM, MegalodonStateType>();

        foreach (MegalodonStateType stateEnum in Enum.GetValues(typeof(MegalodonStateType)))
        {
            string typeName = stateEnum.ToString();
            try
            {
                Type type = Type.GetType($"Megalodon{typeName}State");
                Debug.Log(type);
                MegalodonState stateInstance = Activator.CreateInstance(type, this, stateMachine, typeName) as MegalodonState;

                stateMachine.AddState(stateEnum, stateInstance);
            }
            catch (Exception e)
            {
                Debug.Log($"{typeName} 클래스 인스턴스를 생성할 수 없습니다. {e.Message}");
            }
        }

        stateMachine.Initialize(MegalodonStateType.Chase, this);
    }

    void Update()
    {
        Debug.Log(stateMachine.CurrentState);
        stateMachine.CurrentState.Update();
    }
}
