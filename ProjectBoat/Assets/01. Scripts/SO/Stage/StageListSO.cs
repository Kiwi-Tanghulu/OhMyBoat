using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stage/StageList", order = -1)]
public class StageListSO : ScriptableObject
{
	[SerializeField] List<StageSO> stageList = null;
    public List<StageSO> StageList => stageList;
    
    public StageSO this[int index] => stageList[index];
}
