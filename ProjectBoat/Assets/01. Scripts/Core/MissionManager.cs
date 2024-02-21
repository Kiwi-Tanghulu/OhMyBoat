using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    public event Action<MissionType> OnStartMission;
    public event Action<MissionType> OnEndMission;

    [SerializeField] private float makeMissionInterval;
    private float lastMissionMakeTime;

    private List<Mission> missions;

    private void Awake()
    {
        Instance = this;

        missions = new();
    }

    private void Update()
    {
        if (lastMissionMakeTime + makeMissionInterval < Time.time)
        {
            MakeMission();

            lastMissionMakeTime = Time.time;
        }
    }

    public void RegistMission(Mission misson)
    {
        missions.Add(misson);
    }

    public void MakeMission()
    {
        List<Mission> canStartMissons = missions.FindAll(x => x.CanStartMission());

        if (canStartMissons.Count == 0)
            return;

        int missonIndex = UnityEngine.Random.Range(0, canStartMissons.Count);

        canStartMissons[missonIndex].StartMission();

        OnStartMission?.Invoke(canStartMissons[missonIndex].missonType);
    }

    public void EndMission(Mission misson)
    {
        OnEndMission?.Invoke(misson.missonType);
    }
}
