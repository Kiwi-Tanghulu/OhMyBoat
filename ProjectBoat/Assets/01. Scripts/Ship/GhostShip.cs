using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GhostShip : MonoBehaviour
{
    [Space]
    private Animator anim;
    private readonly int appearHash = Animator.StringToHash("Appear");
    private readonly int disappearHash = Animator.StringToHash("Disappear");

    [Space]
    private Cannon[] cannons;
    private int[] cannonIndices;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        cannons = transform.Find("Cannons").GetComponentsInChildren<Cannon>();
        cannonIndices = new int[cannons.Length];
        for (int i = 0; i < cannons.Length; i++)
            cannonIndices[i] = i;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Appear(true);
        if (Input.GetKeyDown(KeyCode.D))
            Appear(false);
        if (Input.GetKeyDown(KeyCode.E))
            Fire(5);
    }

    public void Appear(bool value)
    {
        if(value)
            anim.SetTrigger(appearHash);
        else
            anim.SetTrigger(disappearHash);
    }

    public void Fire(int fireCount)
    {
        int shuffleCount = 10;
        int a;
        int b;
        int temp;
        for(int i = 0; i < shuffleCount; i++)
        {
            a = UnityEngine.Random.Range(0, cannonIndices.Length);
            b = UnityEngine.Random.Range(0, cannonIndices.Length);
            
            temp = cannonIndices[a];
            cannonIndices[a] = cannonIndices[b];
            cannonIndices[b] = temp;
        }

        for (int i = 0; i < fireCount; i++)
            cannons[cannonIndices[i]].Fire();
    }
}
