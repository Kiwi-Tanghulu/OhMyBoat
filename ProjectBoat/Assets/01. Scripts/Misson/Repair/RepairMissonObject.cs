using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairMissonObject : MissonObject
{
    [Space]
    [SerializeField] protected List<StuffSO> repairStuffs;
    [SerializeField] protected EquipmentSO repairEquip;
                     
    [SerializeField] protected List<StuffSO> currentNeededStuffs;

    public override bool Interact(GameObject performer, bool actived, Vector3 point = default)
    {
        Debug.Log("repair misson interact");
        
        if (performer.TryGetComponent<PlayerHand>(out PlayerHand playerHand))//filled all repair stuff
        {
            if (currentNeededStuffs.Count == 0)
            {
                Equipment equip = playerHand.HoldingObject as Equipment;
                if (equip == null)
                    return false;

                EquipmentSO equipSO = equip.EquipmentData;

                if (equipSO == repairEquip)
                {
                    EndMisson();
                    Debug.Log("success repair misson interact");
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
                    Debug.Log("success repair misson interact");
                    return true;
                }
            }
        }

        Debug.Log("failed repair misson interact");
        return false;
    }

    public override void StartMisson() 
    {
        base.StartMisson();

        for (int i = 0; i < repairStuffs.Count; i++)
            currentNeededStuffs.Add(repairStuffs[i]);
    }

    public override void EndMisson()
    {
        base.EndMisson();
        
        currentNeededStuffs.Clear();
    }
}
