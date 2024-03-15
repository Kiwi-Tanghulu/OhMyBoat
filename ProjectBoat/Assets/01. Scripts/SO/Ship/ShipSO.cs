using UnityEngine;

[CreateAssetMenu(menuName = "SO/Ship/ShipData")]
public class ShipSO : ScriptableObject
{
	public string ShipName = "Nice Ship";
	[TextArea]
    public string Content = "unbubblelievable";
    public Ship ShipPrefab = null;
    public ShipStatSO ShipStat = null;
    public int Level = 0;
}
