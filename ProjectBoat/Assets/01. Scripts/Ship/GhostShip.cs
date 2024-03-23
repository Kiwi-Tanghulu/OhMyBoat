using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShip : MonoBehaviour
{
    private Animator anim;
    private readonly int appearHash = Animator.StringToHash("Appear");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Appear(true);
    }

    public void Appear(bool value)
    {
        anim.SetBool(appearHash, value);
    }
}
