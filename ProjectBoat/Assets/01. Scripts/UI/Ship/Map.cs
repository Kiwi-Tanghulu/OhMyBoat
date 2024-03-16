using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private ShipInputSO inputSO;

    private GameObject map;

    private void Awake()
    {
        map = transform.Find("Map").gameObject;
    }

    private void Start()
    {
        inputSO.OnMEvent += InputSO_OnMEvent;
    }

    private void InputSO_OnMEvent()
    {
        map.SetActive(!map.activeSelf);
    }
}
