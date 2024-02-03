using UnityEngine;

public class THolder : MonoBehaviour, IHolder
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotateSpeed = 360f;

    [Space(10f)]
    [SerializeField] LayerMask grabbableLayer;
    [SerializeField] Transform holdPosition = null;
    public Transform HoldingParent => holdPosition;

    private IGrabbable holdingObject = null;
    public IGrabbable HoldingObject => holdingObject;

    public bool IsEmpty => holdingObject == null;

    private Collider[] detecteds = new Collider[1];

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // float h = Input.GetAxisRaw("Horizontal");
        // float v = Input.GetAxisRaw("Vertical");
        // Vector3 dir = new Vector3(h, 0, v).normalized;

        // if(dir.sqrMagnitude > 0.01f)
        // {
        //     Move(dir);
        //     Rotate(dir);
        // }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(IsEmpty)
            {
                if(DetectItem(out IGrabbable item))
                    Grab(item, holdPosition.position);
            }
            else
                Release();
        }
    }

    private void Move(Vector3 dir)
    {
        transform.position += dir * Time.deltaTime;
    }

    private void Rotate(Vector3 dir)
    {
        Quaternion targetRotation = Quaternion.LookRotation(dir, Vector3.up);
        Quaternion rotate = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        transform.rotation = rotate;
    }

    private bool DetectItem(out IGrabbable item)
    {
        Vector3 detectPosition = holdPosition.position;
        float radius = 0.5f;

        int detectedCount = Physics.OverlapSphereNonAlloc(detectPosition, radius, detecteds, grabbableLayer);
        bool result = detectedCount > 0;

        if(result)
            result = detecteds[0].TryGetComponent<IGrabbable>(out item);
        else
            item = null;

        return result;
    }

    public bool Grab(IGrabbable target, Vector3 point)
    {
        target.Grab(this, point);
        holdingObject = target;

        return true;
    }

    public void Release()
    {
        holdingObject.Release();
        holdingObject = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(holdPosition.position, 0.5f);    
    }
}
