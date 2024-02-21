using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairMissionObject : MissionObject
{
    [Space]
    [SerializeField] protected RepairObjectSO repairObject;
                     
    [SerializeField] protected List<StuffSO> currentNeededStuffs;

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
                    //EndMisson();
                    
                    RepairMission misson = OwnedMisson as RepairMission;
                    misson.StartMiniGame(this);

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
}
