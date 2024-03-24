using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostShip : MonoBehaviour
{
    private Animator anim;
    private readonly int appearHash = Animator.StringToHash("Appear");
    private readonly int disappearHash = Animator.StringToHash("Disappear");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Appear(true);
        if (Input.GetKeyDown(KeyCode.D))
            Appear(false);
    }

    public void Appear(bool value)
    {
        if(value)
            anim.SetTrigger(appearHash);
        else
            anim.SetTrigger(disappearHash);
    }
}
