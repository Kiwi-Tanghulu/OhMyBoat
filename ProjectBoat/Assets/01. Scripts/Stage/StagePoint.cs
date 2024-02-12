using UnityEngine;

public class StagePoint : MonoBehaviour, IFocusable
{
    [SerializeField] int stageIndex = 0;

    public GameObject CurrentObject => gameObject;

    public void Interact()
    {
        StageManager.Instance.StartStage(stageIndex);
    }

    public void OnFocusBegin(Vector3 point)
    {
        // UI 끄기
    }

    public void OnFocusEnd()
    {
        // UI 키기
    }
}
