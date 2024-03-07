using System.Collections.Generic;
using UnityEngine;
using static ImportQuest;

[CreateAssetMenu(menuName = "SO/Quest/ImportQuestData")]
public class ImportQuestSO : QuestSO
{
    [Space(15f)]
    public List<ImportSlip> ImportSlips = new List<ImportSlip>();
}
