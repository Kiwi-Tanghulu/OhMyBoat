using System;
using UnityEngine;

public class QuestBoardVisual : MonoBehaviour, IFocusable
{
	private QuestBoard questBoard = null;
    private Transform focusedVisual = null;
    private Collider visualCollider = null;

    public GameObject CurrentObject => questBoard.gameObject;

    private void Awake()
    {
        questBoard = transform.parent.GetComponent<QuestBoard>();
        focusedVisual = transform.Find("FocusedVisual");
        visualCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        questBoard.OnFocusedEvent += HandleBoardFocused;
    }

    public void OnFocusBegin(Vector3 point)
    {
        focusedVisual.gameObject.SetActive(true);
    }

    public void OnFocusEnd()
    {
        focusedVisual.gameObject.SetActive(false);
    }

    private void HandleBoardFocused(bool focus)
    {
        visualCollider.enabled = !focus;
    }
}
