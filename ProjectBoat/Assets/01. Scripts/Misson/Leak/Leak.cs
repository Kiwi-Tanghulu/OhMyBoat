using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Leak : MissonObject
{
    protected bool isWorking;
    public bool IsWorking => isWorking;

    private ParticleSystem particle;

    [Space]
    [SerializeField] private List<StuffSO> repairStuffs;
    [SerializeField] private EquipmentSO repairEquip;

    [SerializeField] private List<StuffSO> currentNeededStuffs;

    public override void InitMissonObject(Misson misson)
    {
        base.InitMissonObject(misson);

        particle = GetComponent<ParticleSystem>();

        gameObject.SetActive(false);
        particle.Stop();
    }

    public override bool Interact(GameObject performer, bool actived, Vector3 point = default)
    {
        Debug.Log("leak misson interact");

        if(performer.TryGetComponent<PlayerHand>(out PlayerHand playerHand))
        {
            if(currentNeededStuffs.Count == 0)
            {
                Equipment equip = playerHand.HoldingObject as Equipment;
                if (equip == null)
                    return false;

                EquipmentSO equipSO = equip.EquipmentData;

                if (equipSO == repairEquip)
                {
                    EndMisson();
                    Debug.Log("success leak misson interact");
                    return true;
                }
            }
            else
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
                    Debug.Log("success leak misson interact");
                    return true;
                }
            }
        }

        Debug.Log("failed leak misson interact");
        return false;
    }

    public override void StartMisson()
    {
        gameObject.SetActive(true);
        particle.Play();

        for(int i = 0; i < repairStuffs.Count; i++)
            currentNeededStuffs.Add(repairStuffs[i]);

        isWorking = true;
    }

    public override void EndMisson()
    {
        base.EndMisson();

        gameObject.SetActive(false);
        particle.Stop();
        currentNeededStuffs.Clear();

        isWorking = false;
    }
}
