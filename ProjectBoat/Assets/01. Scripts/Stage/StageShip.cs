using System;
using UnityEngine;

public class StageShip : MonoBehaviour
{
    [SerializeField] InputSO input = null;
    [SerializeField] int containerSize = 5;

    [Space(15f)]
	[SerializeField] float detectRadius = 1f;
    [SerializeField] LayerMask detectLayer = 0;

    private Collider[] container = null;
    private IFocusable currentTarget = null;

    private void Awake()
    {
        container = new Collider[containerSize];

        input.OnInteractEvent += HandleInteract;
    }

    private void Update()
    {
        int detected = Physics.OverlapSphereNonAlloc(transform.position, detectRadius, container, detectLayer);
        IFocusable newTarget = SelectTarget(detected);

        if(currentTarget != newTarget)
        {
            currentTarget?.OnFocusEnd();
            currentTarget = newTarget;
            currentTarget?.OnFocusBegin(transform.position);
        }
    }

    private void OnDestroy()
    {
        input.OnInteractEvent -= HandleInteract;
    }

    private void HandleInteract(bool interact)
    {
        if(interact == false)
            return;

        StagePoint stagePoint = currentTarget as StagePoint;
        stagePoint?.Interact();
    }

    private IFocusable SelectTarget(int detected)
    {
        if (detected <= 0)
            return null;

        if (detected > 1)
        {
            Array.Sort(container, (a, b) =>
            {
                float distanceA = a == null ? float.MaxValue : (transform.position - a.transform.position).sqrMagnitude;
                float distanceB = b == null ? float.MaxValue : (transform.position - b.transform.position).sqrMagnitude;

                if (distanceA == distanceB)
                    return 0;
                else if (distanceA > distanceB)
                    return 1;
                else return -1;
            });
        }

        for (int i = 0; i < detected; i++)
            if (container[i].TryGetComponent<IFocusable>(out IFocusable result))
                return result;

        return null;
    }

    #if UNITY_EDITOR
    public bool gizmos = true;
    private void OnDrawGizmos()
    {
        if(gizmos == false)
            return;

        Gizmos.color = Color.red;    
        Gizmos.DrawWireSphere(transform.position, detectRadius);
    }
    #endif
}
