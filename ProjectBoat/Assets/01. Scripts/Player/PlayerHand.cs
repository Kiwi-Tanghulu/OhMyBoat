using System;
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
    private PlayerInventory inventory;

    private void Awake()
    {
        input.OnCollectEvent += HandleCollect;
        focuser = GetComponent<PlayerFocuser>();
        inventory = GetComponent<PlayerInventory>();

        inventory.OnChangeCurrentItemIndex += Inventory_OnChangeCurrentItemIndex;

        DEFINE.PlayerHand = this;
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

    private void Inventory_OnChangeCurrentItemIndex(int value)
    {
        if(holdingObject == null || holdingObject.ObjectType == GrabObjectType.Equipment)
        {
            //Grab(inventory.GetCurrentItem()); right code
            holdingObject?.GrabObject.SetActive(false);
            holdingObject = inventory.GetCurrentItem();
            holdingObject?.GrabObject.SetActive(true);
        }
        Debug.Log(value);
        Debug.Log(inventory.GetCurrentItem());
    }

    private void HandleCollect()
    {
        if(IsEmpty) // 손이 비어있음
        {
            if(focuser.IsEmpty)
                return;

            if(focuser.FocusedObject.CurrentObject.TryGetComponent<IGrabbable>(out IGrabbable target))
            {
                if (target.ObjectType == GrabObjectType.Equipment)
                    inventory.AddItem(target);

                Grab(target);
            }
        }
        else // 무언가 들고 있음
        {
            switch (holdingObject.ObjectType)
            {
                case GrabObjectType.Stuff:
                    Release();

                    //Grab(inventory.GetCurrentItem()); right code
                    holdingObject = inventory.GetCurrentItem();
                    holdingObject?.GrabObject.SetActive(true);
                    break;
                case GrabObjectType.Equipment:
                    if (focuser.IsEmpty)
                        break;

                    if (focuser.FocusedObject.CurrentObject.TryGetComponent<IGrabbable>(out IGrabbable target))
                    {
                        holdingObject.GrabObject.SetActive(false);
                        holdingObject = null;
                        inventory.AddItem(target);
                        Grab(target);
                    }
                    break;
            }
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
