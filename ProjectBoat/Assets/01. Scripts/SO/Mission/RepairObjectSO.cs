using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("SO/Mission/RepairObjectSO"))]
public class RepairObjectSO : ScriptableObject
{
    public List<StuffSO> repairStuffs = new List<StuffSO>();
    public EquipmentSO repairErquipment;
}
