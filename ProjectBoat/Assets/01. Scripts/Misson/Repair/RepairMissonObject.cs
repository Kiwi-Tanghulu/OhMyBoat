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
        if (!actived)
            return false;

        if (performer.TryGetComponent<PlayerHand>(out PlayerHand playerHand))
        {
            if (currentNeededStuffs.Count == 0)//filled all repair stuff
            {
                Equipment equip = playerHand.HoldingObject as Equipment;
                if (equip == null)
                    return false;

                EquipmentSO equipSO = equip.EquipmentData;

                if (equipSO == repairEquip)
                {
                    //EndMisson();
                    
                    RepairMisson misson = OwnedMisson as RepairMisson;
                    misson.StartMiniGame(this);

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

                    return true;
                }
            }
        }

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

    public virtual void ResetMisson()
    {
        for (int i = 0; i < repairStuffs.Count; i++)
            currentNeededStuffs.Add(repairStuffs[i]);
    }
}
