using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissonManager : MonoBehaviour
{
    public static MissonManager Instance;

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
    }
}
