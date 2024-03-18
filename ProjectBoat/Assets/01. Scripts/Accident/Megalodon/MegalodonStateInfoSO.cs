using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AccidentInfo/MegalodonInfo")]
public class MegalodonStateInfoSO : ScriptableObject
{
    public LayerMask shipLayer;
    public float threatRadius;
    public float detectRadius;
}
