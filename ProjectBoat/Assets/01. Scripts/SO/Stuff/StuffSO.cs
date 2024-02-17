using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stuff/StuffData", order = -1)]
public class StuffSO : ScriptableObject
{
    public string StuffName = "unnamed";
    public GameObject prefab = null;
    public Sprite StuffIcon = null;
}
