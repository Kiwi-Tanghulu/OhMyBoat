using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Stuff/CraftingRecipe")]
public class CraftingRecipeSO : ScriptableObject
{
	public List<StuffSO> Requires = new List<StuffSO>();
    public StuffSO Result = null;
}
