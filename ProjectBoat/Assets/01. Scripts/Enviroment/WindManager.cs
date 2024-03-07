using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public static WindManager Instance { get; private set; }

    public Vector3 Wind;


    public TextMeshProUGUI text;
    public Transform arrowTrm;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        text.text = Vector3.Angle(Vector3.forward, Wind.normalized).ToString("F2");
        arrowTrm.localRotation = Quaternion.Euler(0f, 0f, Vector3.Angle(Vector3.forward, Wind.normalized));
    }
}
