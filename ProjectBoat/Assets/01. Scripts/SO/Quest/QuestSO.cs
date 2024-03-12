using UnityEngine;

public abstract class QuestSO : ScriptableObject 
{
    public QuestSlot UIPrefab = null;

    [Space(15f)]
    public RenderTexture npcImage = null;
    public string QuestName = "the quest";
    [TextArea]
    public string QuestContent = "content";

    public abstract Quest CreateQuest(QuestSpot spot);
}
