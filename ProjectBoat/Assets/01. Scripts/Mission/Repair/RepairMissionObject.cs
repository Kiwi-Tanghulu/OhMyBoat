using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairMissionObject : MissionObject
{
    [Space]
    [SerializeField] protected RepairObjectSO repairObject;
                     
    [SerializeField] protected List<StuffSO> currentNeededStuffs;

    public RepairObjectSO RepairObject => repairObject;
    public List<StuffSO> CurrentNeededStuffs => currentNeededStuffs;

    public event Action OnRepairEvent;
    public event Action OnRepairEndEvent;

    private void Start()
    {
        OnFocused += MissionObject_OnFocused;
        OnDefocused += MissionObject_OnDefocused;

        OnRepairEvent += RepairMissionObject_OnRepairEvent;
        OnRepairEndEvent += RepairMissionObject_OnRepairEndEvent;
    }

    public override bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        if (!actived)
            return false;

        PlayerInteractor interactor = performer as PlayerInteractor;
        if (interactor != null)
        {
            PlayerHand playerHand = interactor.Hand;

            if (currentNeededStuffs.Count == 0)//filled all repair stuff
            {
                Equipment equip = playerHand.HoldingObject as Equipment;
                if (equip == null)
                    return false;

                EquipmentSO equipSO = equip.EquipmentData;

                if (equipSO == repairObject.repairErquipment)
                {
                    RepairMission misson = OwnedMisson as RepairMission;
                    misson.StartMiniGame(this);

                    OnRepairEndEvent?.Invoke();

                    OnInteracted?.Invoke(performer);

                    return true;
                }
            }
            else//fill repair stuff
            {
                Stuff stuff = playerHand.HoldingObject as Stuff;
                if (stuff == null)
                    return false;

                StuffSO stuffSO = stuff.StuffData;

                if (currentNeededStuffs.Contains(stuffSO))
                {
                    currentNeededStuffs.Remove(stuffSO);
                    playerHand.Release();
                    Destroy(stuff.gameObject);

                    OnRepairEvent?.Invoke();

                    OnInteracted?.Invoke(performer);

                    return true;
                }
            }
        }

        return false;
    }

    public override void StartMission()
    {
        base.StartMission();

        currentNeededStuffs.Clear();

        for (int i = 0; i < repairObject.repairStuffs.Count; i++)
            currentNeededStuffs.Add(repairObject.repairStuffs[i]);
    }

    public override void FailureMission()
    {
        isWorking = true;

        for (int i = 0; i < repairObject.repairStuffs.Count; i++)
            currentNeededStuffs.Add(repairObject.repairStuffs[i]);
    }

    private void MissionObject_OnFocused(Vector3 point)
    {
        RepairUI.Instance.Draw(repairObject, currentNeededStuffs);
    }

    private void MissionObject_OnDefocused()
    {
        RepairUI.Instance.Hide();
    }

    private void RepairMissionObject_OnRepairEvent()
    {
        RepairUI.Instance.Draw(repairObject, currentNeededStuffs);
    }

    private void RepairMissionObject_OnRepairEndEvent()
    {
        RepairUI.Instance.Hide();
    }
}
