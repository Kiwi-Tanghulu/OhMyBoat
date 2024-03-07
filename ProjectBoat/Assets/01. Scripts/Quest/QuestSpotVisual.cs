using UnityEngine;

public class QuestSpotVisual : MonoBehaviour, IFocusable
{
    public GameObject CurrentObject => questSpot.gameObject;

    private QuestSpot questSpot = null;

    private void Awake()
    {
        questSpot = transform.parent.GetComponent<QuestSpot>();
    }

    public void OnFocusBegin(Vector3 point)
    {
        
    }

    public void OnFocusEnd()
    {
        
    }
}
