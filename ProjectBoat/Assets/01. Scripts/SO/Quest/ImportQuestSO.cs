using System.Collections.Generic;
using UnityEngine;
using static ImportQuest;

[CreateAssetMenu(menuName = "SO/Quest/ImportQuestData")]
public class ImportQuestSO : QuestSO
{
    public List<ImportSlip> ImportSlips = new List<ImportSlip>();
}
