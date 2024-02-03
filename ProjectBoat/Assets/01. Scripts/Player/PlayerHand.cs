using UnityEngine;

public class PlayerHand : MonoBehaviour, IHolder
{
    [SerializeField] InputSO input;

    [Space(15f)]
    [SerializeField] Transform holdPosition = null;
    public Transform HoldingParent => holdPosition;

    private IGrabbable holdingObject = null;
    public IGrabbable HoldingObject => holdingObject;

    public bool IsEmpty => holdingObject == null;

    private PlayerFocuser focuser = null;

    private void Awake()
    {
        input.OnCollectEvent += HandleCollect;
        focuser = GetComponent<PlayerFocuser>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        input.OnCollectEvent -= HandleCollect;
    }

    private void HandleCollect()
    {
        if(IsEmpty) // 손이 비어있음
        {
            if(focuser.IsEmpty)
                return;

            if(focuser.FocusedObject.CurrentObject.TryGetComponent<IGrabbable>(out IGrabbable target))
                Grab(target);
        }
        else // 무언가 들고 있음
        {
            Release();
        }
    }

    public bool Grab(IGrabbable target, Vector3 point = default)
    {
        bool result = target.Grab(this, point);
        if(result)
            holdingObject = target;

        return result;
    }

    public void Release()
    {
        holdingObject.Release();
        holdingObject = null;
    }
}
