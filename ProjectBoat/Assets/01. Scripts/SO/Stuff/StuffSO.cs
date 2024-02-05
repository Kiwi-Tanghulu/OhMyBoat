using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stuff/StuffData")]
public class StuffSO : ScriptableObject
{
    public string StuffName = "unnamed";
    public GameObject prefab = null;
    public Sprite StuffIcon = null;
}
