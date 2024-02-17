using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stage/StageData")]
public class StageSO : ScriptableObject
{
    public GameObject StagePrefab;
	public float PlayTime = 60f;
}
