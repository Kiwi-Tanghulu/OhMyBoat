using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stage/StageData")]
public class StageSO : ScriptableObject
{
    public Stage StagePrefab;
	public float PlayTime = 60f;
    
    [Space(15f)]
    public Sprite StageImage = null;
    [TextArea]
    public string StageCaption = "GOOD STAGE";

    [Space(15f)]
    [Range(0f, 5f)] public float DamageFactor = 1f;
    public int DamageLimit = 100;

    public int EarnedStar = 0;
}
