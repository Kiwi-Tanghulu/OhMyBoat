using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "SO/LeakTransformSO")]
public class LeakTransformSO : ScriptableObject
{
    [System.Serializable]
    public class Transform
    {
        public Vector3 position;
        public Vector3 rotation;
    }

    public List<Transform> LeakTransforms;
}
