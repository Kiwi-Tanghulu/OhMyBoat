using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiseongTest : MonoBehaviour
{
    private BoxCollider boxCol;
    [SerializeField] LayerMask ground;
    private void Awake()
    {
        boxCol = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
            Debug.Log("°¨Áö" + Physics.OverlapBox(boxCol.transform.position + boxCol.center, boxCol.size / 2, Quaternion.identity,ground).Length);
        
    }
}
