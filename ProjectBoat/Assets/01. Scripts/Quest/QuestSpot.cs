using System;
using UnityEngine;

public class QuestSpot : MonoBehaviour, IInteractable
{
    private Quest currentQuest = null;

    public bool QuestActive => (currentQuest != null);
    public event Func<StuffSO, bool> OnQuestProcessEvent;

    #region Test Codes
    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
            if(Input.GetKeyDown(KeyCode.Alpha0))
                FinishQuest();
    }
    #endregion

    /// <summary>
    /// only quest calls
    /// </summary>
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

        if(ProcessQuest(holdingStuff.StuffData) == false)
            return false;

        hand.Release();
        Destroy(holdingStuff.gameObject);

        return true;
    }

    private bool ProcessQuest(StuffSO stuffData)
    {
        if(OnQuestProcessEvent == null)
            return false;

        return OnQuestProcessEvent.Invoke(stuffData);
    }
}
