using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;

    public event Action<MissionType> OnStartMission;
    public event Action<MissionType, bool> OnEndMission;

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
        MakeMission();
    }

    public void RegistMission(Mission misson)
    {
        missions.Add(misson);
    }

    public void MakeMission()
    {
        #region Æó±â
        List<Mission> canStartMissons = missions.FindAll(x => x.CanStartMission());

        if (canStartMissons.Count == 0)
            return;

        int missonIndex = UnityEngine.Random.Range(0, canStartMissons.Count);

        canStartMissons[missonIndex].StartMission();

        OnStartMission?.Invoke(canStartMissons[missonIndex].missonType);
        #endregion
        for (int i = 0; i < missions.Count; i++)
        {
            if (missions[i].CanStartMission())
            {
                missions[i].StartMission();
                OnStartMission?.Invoke(missions[i].missonType);
            }
        }
    }

    public void EndMission(Mission misson, bool isSuccess)
    {
        OnEndMission?.Invoke(misson.missonType, isSuccess);
    }
}
