using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissonManager : MonoBehaviour
{
    public static MissonManager Instance;

    [SerializeField] private float makeMissonInterval;
    private float lastMissonMakeTime;

    private List<Misson> missons;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        missons = new();
    }

    private void Update()
    {
        if (lastMissonMakeTime + makeMissonInterval < Time.time)
        {
            //MakeMisson();

            lastMissonMakeTime = Time.time;
        }
    }

    public void RegistMisson(Misson misson)
    {
        missons.Add(misson);
    }

    public void MakeMisson()
    {
        int missonIndex;
        do
        {
            missonIndex = UnityEngine.Random.Range(0, missons.Count);
        }
        while (!missons[missonIndex].CanMakeMisson());

        missons[missonIndex].StartMisson();
    }
}
