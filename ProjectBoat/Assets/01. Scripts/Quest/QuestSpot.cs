using System;
using UnityEngine;

public class QuestSpot : MonoBehaviour, IInteractable
{
    private Quest currentQuest = null;

    public bool QuestActive => (currentQuest != null);
    public event Action<StuffSO> OnQuestProcessEvent;

    public void StartQuest(Quest quest)
    {
        currentQuest = quest;
    }

    public void FinishQuest()
    {
        currentQuest.FinishQuest();
        currentQuest = null;
    }

    public bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        if(actived == false)
            return false;

        if(QuestActive == false)
            return false;

        PlayerHand hand = (performer as PlayerInteractor)?.Hand;
        if(hand == null || hand.IsEmpty)
            return false;

        Stuff holdingStuff = hand.HoldingObject as Stuff;
        if (holdingStuff == null)
            return false;

        ProcessQuest(holdingStuff.StuffData);

        hand.Release();
        Destroy(holdingStuff.gameObject);

        return true;
    }

    private void ProcessQuest(StuffSO stuffData)
    {
        OnQuestProcessEvent?.Invoke(stuffData);
    }
}
