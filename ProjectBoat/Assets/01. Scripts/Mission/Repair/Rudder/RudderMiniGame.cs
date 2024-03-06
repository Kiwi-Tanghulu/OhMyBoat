using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RudderMiniGame : RepairMiniGame
{
    [SerializeField] private TextMeshProUGUI[] answerTexts;
    [SerializeField] private TextMeshProUGUI currentText;

    private int answerNum;

    private int currentNum;

    private int currentOrder;
    public override void StartGame(RepairMissionObject missonObject)
    {
        base.StartGame(missonObject);

        foreach(TextMeshProUGUI answerText in answerTexts)
        {
            answerText.text = "?";
        }

        currentText.text = "0";

        answerNum = Random.Range((int)0, 10);
        currentOrder = 1;

        inputSO.OnAEvent += Input_AEvent;
        inputSO.OnDEvent += Input_DEvent;
        inputSO.OnSpaceEvent += Input_SpaceEvent;
    }

    public override void EndGame(bool result)
    {
        base.EndGame(result);

        inputSO.OnAEvent -= Input_AEvent;
        inputSO.OnDEvent -= Input_DEvent;
        inputSO.OnSpaceEvent -= Input_SpaceEvent;
    }

    private void NextNum()
    {
        answerNum = Random.Range((int)0, 10);

        currentOrder++;
    }

    private void CheckNum()
    {
        if (currentNum == answerNum)
        {

            NextNum();
        }
        else
        {

        }
    }

    private void Input_AEvent()
    {
        
    }

    private void Input_DEvent()
    {

    }

    private void Input_SpaceEvent()
    {
        CheckNum();
    }
}
