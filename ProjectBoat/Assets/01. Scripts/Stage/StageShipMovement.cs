using UnityEngine;

public class StageShipMovement : MonoBehaviour
{
	[SerializeField] PlayInputSO input = null;
    
    [Space(15f)]
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float rotateDuration = 15f;

    private Vector3 moveDirection = Vector3.zero;

    private Quaternion prevRotation = Quaternion.identity;
    private Quaternion targetRotation = Quaternion.identity;
    private float theta = 0f;

    private void Awake()
    {
        input.OnMoveEvent += HandleMove;
    }

    private void FixedUpdate()
    {
        if(moveDirection.sqrMagnitude <= 0.1f)
            return;

        Rotate();
        transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime, Space.World);
    }

    private void OnDestroy()
    {
        input.OnMoveEvent -= HandleMove;
    }

    private void Rotate()
    {
        if(theta >= 1f)
            return;

        theta = Mathf.Min(theta + (Time.fixedDeltaTime / rotateDuration), 1f);
        transform.rotation = Quaternion.Lerp(prevRotation, targetRotation, theta);
    }

    private void HandleMove(Vector2 input)
    {
        moveDirection = new Vector3(input.x, 0f, input.y);
        if(moveDirection.sqrMagnitude <= 0.1f)
            return;

        theta = 0f;
        prevRotation = transform.rotation;
        targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
    }
}
