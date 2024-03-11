using UnityEngine;

public class QuestSpotVisual : MonoBehaviour, IFocusable
{
    public GameObject CurrentObject => questSpot.gameObject;

    private QuestSpot questSpot = null;
    private Transform focusedVisual = null; 

    private void Awake()
    {
        questSpot = transform.parent.GetComponent<QuestSpot>();
        focusedVisual = transform.Find("FocusedVisual");
    }

    public void OnFocusBegin(Vector3 point)
    {
        focusedVisual.gameObject.SetActive(true);
    }

    public void OnFocusEnd()
    {
        focusedVisual.gameObject.SetActive(false);
    }
}
