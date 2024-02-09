using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leak : MonoBehaviour, IInteractable
{
    public static event Action<Leak> OnStartWork;
    public static event Action<Leak> OnEndWork;

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

        OnEndWork?.Invoke(this);
    }

    private void EndWork()
    {
        gameObject.SetActive(false);
        particle.Stop();

        isWorking = false;

        OnEndWork?.Invoke(this);
    }

    public bool Interact(GameObject performer, bool actived, Vector3 point = default)
    {
        Debug.Log("leak misson interact");

        return true;
    }

    public static void InitLeak()
    {
        OnStartWork = null;
        OnEndWork = null;
    }
}
