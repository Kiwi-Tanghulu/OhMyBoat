using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak : MonoBehaviour, IInteractable
{
    private bool isWorking;
    public bool IsWorking => isWorking;

    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        EndWork();
    }

    public void StartWork()
    {
        gameObject.SetActive(true);
        particle.Play();

        isWorking = true;
    }

    private void EndWork()
    {
        gameObject.SetActive(false);
        particle.Stop();

        isWorking = false;
    }

    public bool Interact(GameObject performer, bool actived, Vector3 point = default)
    {
        Debug.Log("leak misson interact");

        return true;
    }
}
