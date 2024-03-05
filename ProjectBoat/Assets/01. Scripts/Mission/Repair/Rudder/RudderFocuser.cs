using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderFocuser : MonoBehaviour, IFocusable
{
    [SerializeField] private RudderMissionObject rudder;

    public GameObject CurrentObject => rudder.gameObject;

    public void OnFocusBegin(Vector3 point)
    {
        rudder.OnFocusBegin(point);
    }

    public void OnFocusEnd()
    {
        rudder.OnFocusEnd();
    }
}
