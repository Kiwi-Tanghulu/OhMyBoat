using UnityEngine;

[CreateAssetMenu(menuName = "SO/Quest/DeliveryQuestData")]
public class DeliveryQuestSO : QuestSO
{
	public StuffSO RequireStuff = null;
    [Range(1, 30)] public int RequireQuantity = 1;
}
