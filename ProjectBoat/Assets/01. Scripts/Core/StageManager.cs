using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance = null;

    [SerializeField] StageListSO stageList = null;

    private GameObject stageBoard = null;
    private GameObject currentStage = null;

    public bool IsPlaying { get; private set; } = false;

    private void Awake()
    {
        if(Instance != null)
            Destroy(Instance);

        Instance = this;

        stageBoard = GameObject.Find("StageBoard");
    }

    public void StartStage(int index)
    {
        if(IsPlaying)
            return;

        stageBoard.SetActive(false);
        IsPlaying = true;
        
        currentStage = Instantiate(stageList[index], Vector3.zero, Quaternion.identity);
    }

    public void FinishStage()
    {
        Destroy(currentStage);
        stageBoard.SetActive(true);
    }
}
