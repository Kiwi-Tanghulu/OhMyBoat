using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftingTable : MonoBehaviour, IInteractable
{
	[SerializeField] CraftingRecipeSO recipe;
    [SerializeField] Transform spawnPosition;

    private List<StuffSO> craftingProcess = null;
    private PlayerHand playerHand = null;

    private void Awake()
    {
        ResetProcess();
    }

    private void Start()
    {
        playerHand = DEFINE.PlayerHand;
    }

    public bool Interact(GameObject performer, bool actived, Vector3 point = default)
    {
        if(actived == false)
            return false;

        if(playerHand.IsEmpty)
            return false;

        return CraftingProcess();
    }

    private bool CraftingProcess()
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
