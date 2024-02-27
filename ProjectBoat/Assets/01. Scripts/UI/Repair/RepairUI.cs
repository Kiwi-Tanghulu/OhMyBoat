using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairUI : MonoBehaviour
{
    public static RepairUI Instance { get; private set; }

    [SerializeField] private RepairStuffUI repairStuffUI;
    [SerializeField] private RepairStuffIconUI repairEquipIcon;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Hide();
    }

    public void Draw(RepairObjectSO repairObjects, List<StuffSO> currentNeededStuffs)
    {
        repairStuffUI.Draw(repairObjects.repairStuffs, currentNeededStuffs);

        repairEquipIcon.SetIcon(repairObjects.repairErquipment.StuffIcon);
        //repairEquipIcon.SetBackground(Color.red);
        //for (int i = 0; i < inventory.MaxItemCount; i++)
        //{
        //    Equipment equip = inventory.Inventory[i] as Equipment;

        //    if(equip)
        //    {
        //        if (equip.EquipmentData == repairObjects.repairErquipment)
        //            repairEquipIcon.SetBackground(Color.green);
        //    }
        //}
        repairEquipIcon.gameObject.SetActive(true);
    }

    public void Hide()
    {
        repairStuffUI.Hide();
        repairEquipIcon.gameObject.SetActive(false);
    }
}
