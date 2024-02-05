using UnityEngine;

public class CraftingTableVisual : MonoBehaviour, IFocusable
{
	private CraftingTable stuff = null;
    private Transform focusedVisual = null; 

    public GameObject CurrentObject => stuff.gameObject;

    private void Awake()
    {
        stuff = transform.parent.GetComponent<CraftingTable>();
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
