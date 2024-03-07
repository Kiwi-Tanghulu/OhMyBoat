using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public static WindManager Instance { get; private set; }

    public Vector3 Wind;

    private void Awake()
    {
        Instance = this;
    }
}
