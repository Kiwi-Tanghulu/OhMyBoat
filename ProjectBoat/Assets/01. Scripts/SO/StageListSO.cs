using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/StageList")]
public class StageListSO : ScriptableObject
{
	[SerializeField] List<GameObject> stageList = null;
    public List<GameObject> StageList => stageList;
    
    public GameObject this[int index] => stageList[index];
}
