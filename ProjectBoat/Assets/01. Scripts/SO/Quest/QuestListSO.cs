using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Quest/QuestList", order = -1)]
public class QuestListSO : ScriptableObject
{
	[SerializeField] List<QuestSO> questList = null;
    public List<QuestSO> QuestList => questList;

    public QuestSO this[int index] => questList[index];
}
