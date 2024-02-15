using System;
using UnityEngine;

public class PlayerHand : MonoBehaviour, IHolder
{
    [SerializeField] PlayInputSO input;

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
        input.OnFireEvent += HandleFire;
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
        if (holdingObject is Stuff)
            return;

        holdingObject?.GrabObject.SetActive(false);
        holdingObject = inventory.GetCurrentItem();
        holdingObject?.GrabObject.SetActive(true);
    }

    private void HandleFire()
    {
        Equipment equipment = holdingObject as Equipment;
        if(equipment == null)
            return;

        int remaining = equipment.Active();
        if(remaining <= 0)
        {
            // Release();
            inventory.RemoveItem(equipment);
            Destroy(equipment.gameObject);
            holdingObject = null;
        }
    }

    private void HandleCollect()
    {
        if (IsEmpty) // 손이 비어있음
        {
            if (focuser.IsEmpty)
                return;

            if (focuser.FocusedObject.CurrentObject.TryGetComponent<IGrabbable>(out IGrabbable target))
            {
                if (target is Equipment)
                    inventory.AddItem(target);

                Grab(target);
            }
        }
        else // 무언가 들고 있음
        {
            if (holdingObject is Stuff)
            {
                Release();

                //Grab(inventory.GetCurrentItem()); right code
                holdingObject = inventory.GetCurrentItem();
                holdingObject?.GrabObject.SetActive(true);
            }
            else if (holdingObject is Equipment)
            {
                if (focuser.IsEmpty)
                    return;

                if (focuser.FocusedObject.CurrentObject.TryGetComponent<IGrabbable>(out IGrabbable target))
                {
                    holdingObject.GrabObject.SetActive(false);
                    holdingObject = null;
                    Grab(target);

                    if(target is Equipment)
                        inventory.AddItem(target);
                }
            }
        }
    }

    public bool Grab(IGrabbable target, Vector3 point = default)
    {
        bool result = target.Grab(this, point);

        if (result)
            holdingObject = target;

        return result;
    }

    public void Release()
    {
        holdingObject.Release();
        holdingObject = null;
    }
}
