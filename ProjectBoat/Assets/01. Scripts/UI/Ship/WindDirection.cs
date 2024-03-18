using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindDirection : MonoBehaviour
{
    [SerializeField] private Ship ship;

    private Transform windDirectionTrm;
    private Transform verticalSailDirectionTrm;
    private Transform horizontalSailDirectionTrm;
    private Transform sailDirectionTrm;
    private WindManager wind;

    private void Start()
    {
        wind = WindManager.Instance;
        windDirectionTrm = transform.Find("WindDirection");
        verticalSailDirectionTrm = transform.Find("VerticalSailDirection");
        horizontalSailDirectionTrm = transform.Find("HorizontalSailDirection");

        if(ship.Sail.sailType == SailType.Horizontal)
        {
            sailDirectionTrm = horizontalSailDirectionTrm;
            verticalSailDirectionTrm.gameObject.SetActive(false);
        }
        else
        {
            sailDirectionTrm = verticalSailDirectionTrm;
            horizontalSailDirectionTrm.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(Vector3.forward, wind.Wind.normalized));

        windDirectionTrm.rotation = Quaternion.Euler(0f, 0f, angle);
        sailDirectionTrm.rotation = Quaternion.Euler(0f, 0f, -ship.Sail.transform.eulerAngles.y);
    }
}
