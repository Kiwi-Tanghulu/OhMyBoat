using UnityEngine;
using UnityEngine.UI;

public class StageStar : MonoBehaviour
{
	private Image starIcon = null;

    private void Awake()
    {
        starIcon = transform.Find("StarIcon")?.GetComponent<Image>();   
    }

    public void Display(bool active)
    {
        if(active)
            Show();
        else
            Hide();
    }

    private void Show()
    {
        starIcon.gameObject.SetActive(true);
    }

    private void Hide()
    {
        starIcon.gameObject.SetActive(false);
    }
}
