using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class Port : MonoBehaviour
{
    [SerializeField] UIInputSO input = null;
    [SerializeField] PortSO portData = null;

    [Space(15f)]
    [SerializeField] float rotateSpeed = 5f;
    // [SerializeField] float zoomSpeed = 5f;
    // [SerializeField] Vector2 zoomClamp = new Vector2(1f, 50f);

    [Space(15f)]
    [SerializeField] GameObject currentShip = null;
    [SerializeField] Transform shipSpawnPoint = null;

    [Space(15f)]
    public UnityEvent OnPortOpenEvent = null;
    public UnityEvent OnPortCloseEvent = null;
    public UnityEvent OnCurrentShipChangedEvent = null;

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

        portPanel.OnPurchaseEvent += HandlePurchase;
        portPanel.OnUpgradeEvent += HandlePurchase;
    }

    private void FixedUpdate()
    {
        if(focused == false)
            return;

        focusPoint.Rotate(Vector3.up, -rotateSpeed * Time.fixedDeltaTime);
    }

    private void OnDestroy()
    {
        
    }

    public void Initialize()
    {
        focused = true;
        focusCam.Priority = FOCUSED_PRIORITY;
        InputManager.ChangeInputMap(InputMapType.UI);
        GameManager.Instance.CursorActive(focused);

        portData.ChangeShip(portData.CurrentShipIndex);

        portPanel.Initialize(portData.CurrentShipData);
        portPanel.Display(true);

        input.OnEscapeEvent += HandleEscape;
        portData.OnCurrentShipChangedEvent += HandleShipChanged;

        OnPortOpenEvent?.Invoke();
    }

    public void Release()
    {
        focused = false;
        focusCam.Priority = UNFOCUSED_PRIORITY;
        InputManager.ChangeInputMap(InputMapType.Play);
        GameManager.Instance.CursorActive(focused);

        portPanel.Release();
        portPanel.Display(false);

        input.OnEscapeEvent -= HandleEscape;
        portData.OnCurrentShipChangedEvent -= HandleShipChanged;

        OnPortCloseEvent?.Invoke();
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

    private void HandleShipChanged()
    {
        if(currentShip != null)
            Destroy(currentShip.gameObject);

        GameObject prefab = portData.CurrentShipData.ShipPrefab;
        currentShip = Instantiate(prefab, shipSpawnPoint.position, shipSpawnPoint.rotation);
        OnCurrentShipChangedEvent?.Invoke();
    }
}

