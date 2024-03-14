using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGenerator : MonoBehaviour
{
    [SerializeField] private GameObject waterPrefab;
    [SerializeField] private Vector3 startPoint;
    [SerializeField] private Vector3 waterSize;
    [SerializeField] private Vector2 waterCount;

    private void Start()
    {
        Vector3 pos;
        GameObject water;

        for(int i = 0; i < waterCount.x; i++)
        {
            for(int j = 0; j < waterCount.y; j++)
            {
                pos = new Vector3(startPoint.x + waterSize.x * j, startPoint.y, startPoint.z + waterSize.z * i);
                water = Instantiate(waterPrefab, pos, Quaternion.identity, transform);
            }
        }
    }
}
