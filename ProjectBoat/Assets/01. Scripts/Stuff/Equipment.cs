using System;
using UnityEngine;

public abstract class Equipment : MonoBehaviour, IGrabbable
{
    [SerializeField] EquipmentSO equipmentData;
    public EquipmentSO EquipmentData => equipmentData;

    protected int durability = 0;

    private IHolder currentHolder = null;
    public IHolder CurrentHolder => currentHolder;

    public GameObject GrabObject => gameObject;

    public event Action<bool> OnGrabbedEvent = null;
    public event Action OnBrokenEvent = null;

    public abstract void OnEquipmentActived();

    public void Active()
    {
        OnEquipmentActived();

        durability--;
        if(durability <= 0)
        {
            OnBrokenEvent?.Invoke();
            Destroy(gameObject);   
        }
    }
    
    public void Init()
    {
        durability = equipmentData.MaxDurability;
    }

    public bool Grab(IHolder holder, Vector3 point = default)
    {
        if (holder.IsEmpty == false)
            return false;

        if (currentHolder != null)
            return false;

        currentHolder = holder;
        transform.SetParent(currentHolder.HoldingParent);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        OnGrabbedEvent?.Invoke(true);

        return true;
    }

    public void Release()
    {
        currentHolder = null;
        transform.SetParent(null);
        transform.localRotation = Quaternion.Euler(0f, transform.localEulerAngles.y, 0f);
        OnGrabbedEvent?.Invoke(false);
    }
}
