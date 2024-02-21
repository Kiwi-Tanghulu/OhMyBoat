using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailFocuser : MonoBehaviour, IFocusable
{
    [SerializeField] private SailMissionObject sail;

    public GameObject CurrentObject => sail.gameObject;

    public void OnFocusBegin(Vector3 point)
    {
        sail.OnFocusBegin(point);
    }

    public void OnFocusEnd()
    {
        sail.OnFocusEnd();
    }
}
