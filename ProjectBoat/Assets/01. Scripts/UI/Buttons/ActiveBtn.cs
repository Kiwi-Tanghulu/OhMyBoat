using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBtn : MonoBehaviour
{
    public GameObject activeObject;
    public GameObject deactiveObject;

    public void ActiveObject()
    {
        activeObject.SetActive(true);
        deactiveObject.SetActive(false);
    }
}
