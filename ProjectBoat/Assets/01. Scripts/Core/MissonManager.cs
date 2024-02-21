using System;
using System.Collections.Generic;
using UnityEngine;

public class MissonManager : MonoBehaviour
{
    public static MissonManager Instance;

    public event Action<MissonType> OnStartMisson;
    public event Action<MissonType> OnEndMisson;

    [SerializeField] private float makeMissonInterval;
    private float lastMissonMakeTime;

    private List<Misson> missons;

    private void Awake()
    {
        Instance = this;

        missons = new();
    }

    private void Update()
    {
        if (lastMissonMakeTime + makeMissonInterval < Time.time)
        {
            MakeMisson();

            lastMissonMakeTime = Time.time;
        }
    }

    public void RegistMisson(Misson misson)
    {
        missons.Add(misson);
    }

    public void MakeMisson()
    {
        List<Misson> canStartMissons = missons.FindAll(x => x.CanStartMisson());

        if (canStartMissons.Count == 0)
            return;

        int missonIndex = UnityEngine.Random.Range(0, canStartMissons.Count);

        canStartMissons[missonIndex].StartMisson();

        OnStartMisson?.Invoke(canStartMissons[missonIndex].missonType);
    }

    public void EndMisson(Misson misson)
    {
        OnEndMisson?.Invoke(misson.missonType);
    }
}
