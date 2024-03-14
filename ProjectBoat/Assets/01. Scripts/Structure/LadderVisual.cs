using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderVisual : MonoBehaviour, IFocusable
{
    private Ladder ladder = null;
    private Transform focusedVisual;
    public GameObject CurrentObject => ladder.gameObject;

    private void Awake()
    {
        ladder = transform.GetComponent<Ladder>();
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
