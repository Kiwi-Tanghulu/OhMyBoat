using UnityEngine;

public partial class ImportQuest
{
    [System.Serializable]
    public class ImportSlip
    {
        public StuffSO RequireStuff = null;
        [Range(1f, 5f)] public float PriceCoefficient = 1.1f;
    }
}
