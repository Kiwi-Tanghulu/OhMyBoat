using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUIBtn : MonoBehaviour
{
    public GameObject activeObject;
    public GameObject deactiveObject;

    public void ChangeUI()
    {
        activeObject.SetActive(true);
        deactiveObject.SetActive(false);
    }
}
