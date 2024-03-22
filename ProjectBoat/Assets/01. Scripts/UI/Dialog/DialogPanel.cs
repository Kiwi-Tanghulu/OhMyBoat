using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogPanel : MonoBehaviour
{
    [SerializeField] float breakDelay = 0.5f;

	private TMP_Text nameText = null;
    private TMP_Text contentText = null;

    private void Awake()
    {
        nameText = transform.Find("DialogBackground/NameTag/NameText").GetComponent<TMP_Text>();
        contentText = transform.Find("DialogBackground/ContentText").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        Display(false);
    }

    public void SetContext(DialogContextSO contextData, string name, Action callback = null)
    {
        nameText.text = name;
        StartCoroutine(FillContentRoutine(contextData.Dialog, callback));
    }
    
    public void Release()
    {
        nameText.text = "";
        contentText.text = "";
    }

    public void Display(bool active)
    {
        gameObject.SetActive(active);
    }

    private IEnumerator FillContentRoutine(string text, Action callback)
    {
        YieldInstruction delay = new WaitForSeconds(breakDelay);
        for(int i = 0; i < text.Length; ++i)
        {
            contentText.text = text[..(i + 1)];
            yield return delay;
        }

        callback?.Invoke();
    }
}
