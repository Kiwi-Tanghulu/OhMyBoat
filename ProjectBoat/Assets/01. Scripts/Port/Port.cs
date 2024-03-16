using Cinemachine;
using UnityEngine;

public class Port : MonoBehaviour
{
    [SerializeField] UIInputSO input = null;

    [Space(15f)]
    [SerializeField] float rotateSpeed = 5f;
    // [SerializeField] float zoomSpeed = 5f;
    // [SerializeField] Vector2 zoomClamp = new Vector2(1f, 50f);

	private const int FOCUSED_PRIORITY = 20;
    private const int UNFOCUSED_PRIORITY = 1;

    private PortPanel portPanel = null;
    private Transform focusPoint = null;
    private CinemachineVirtualCamera focusCam = null;
    private bool focused = false;

    private void Awake()
    {
        portPanel = DEFINE.MainCanvas.Find("PortPanel").GetComponent<PortPanel>();
        focusPoint = transform.Find("FocusPoint");
        focusCam = focusPoint.Find("FocusCam").GetComponent<CinemachineVirtualCamera>();

        input.OnEscapeEvent += HandleEscape;
        portPanel.OnPurchaseEvent += HandlePurchase;
        portPanel.OnUpgradeEvent += HandlePurchase;
    }

    private void FixedUpdate()
    {
        if(focused == false)
            return;

        focusPoint.Rotate(Vector3.up, -rotateSpeed * Time.fixedDeltaTime);
    }

    public void Initialize()
    {
        focused = true;
        focusCam.Priority = FOCUSED_PRIORITY;
        InputManager.ChangeInputMap(InputMapType.UI);
        GameManager.Instance.CursorActive(focused);

        portPanel.Display(true);
    }

    public void Release()
    {
        focused = false;
        focusCam.Priority = UNFOCUSED_PRIORITY;
        InputManager.ChangeInputMap(InputMapType.Play);
        GameManager.Instance.CursorActive(focused);
    }

    private void HandleEscape()
    {
        Release();
    }

    private void HandlePurchase(ShipSO shipData)
    {
        if(shipData.IsPurchased == false)
            shipData.IsPurchased = true;

        if(shipData.Level > DEFINE.ShipMaxLevel)
            return;

        shipData.ModifyLevel(1);
    }
}

