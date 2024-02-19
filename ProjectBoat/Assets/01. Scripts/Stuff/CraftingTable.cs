using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftingTable : MonoBehaviour, IInteractable
{
	[SerializeField] CraftingRecipeSO recipe;
    [SerializeField] Transform spawnPosition;

    private List<StuffSO> craftingProcess = null;

    private void Awake()
    {
        ResetProcess();
    }

    public bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        if(actived == false)
            return false;

        PlayerHand hand = (performer as PlayerInteractor)?.Hand;
        if(hand == null || hand.IsEmpty)
            return false;

        return CraftingProcess(hand);
    }

    private bool CraftingProcess(PlayerHand playerHand)
    {
        Stuff holdingStuff = playerHand.HoldingObject as Stuff;
        if(holdingStuff == null)
            return false;

        if(craftingProcess.Contains(holdingStuff.StuffData) == false)
            return false;

        playerHand.Release();
        craftingProcess.Remove(holdingStuff.StuffData);
        Destroy(holdingStuff.gameObject);

        if(craftingProcess.Count <= 0)
            OnCrafted();

        return true;
    }

    private void ResetProcess()
    {
        craftingProcess = recipe.Requires.ToList();
    }

    private void OnCrafted()
    {
        Instantiate(recipe.Result.prefab, spawnPosition.position, spawnPosition.rotation);
        ResetProcess();
    }
}
