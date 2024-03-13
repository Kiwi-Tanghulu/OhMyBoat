using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stuff/StuffData", order = -1)]
public class StuffSO : ScriptableObject
{
    public string StuffName = "unnamed";
    [TextArea]
    public string StuffContent = "nice stuff";
    public GameObject prefab = null;
    public Sprite StuffIcon = null;
    public int Price = 10;
    public int Weight = 10;
}
