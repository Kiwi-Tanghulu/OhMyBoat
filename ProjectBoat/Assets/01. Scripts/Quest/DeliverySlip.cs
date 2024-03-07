using UnityEngine;

public partial class DeliveryQuest
{
    [System.Serializable]
    public class DeliverySlip
    {
        public StuffSO RequireStuff = null;
        [Range(1, 30)] public int RequireQuantity = 1;
    }
}