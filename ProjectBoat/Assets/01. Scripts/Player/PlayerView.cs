using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private InputSO input;
    [SerializeField] private CinemachineVirtualCamera playerCam;

    [SerializeField] private float rotateSpeed;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] private bool inverseX;
    [SerializeField] private bool inverseY;

    private void Awake()
    {
        input.OnMouseDeltaEvent += PlayerRotate;
        input.OnMouseDeltaEvent += CameraRotate;
    }

    private void OnDestroy()
    {
        input.OnMouseDeltaEvent -= PlayerRotate;
        input.OnMouseDeltaEvent -= CameraRotate;
    }

    private void PlayerRotate(Vector2 mouseDelta)
    {
        Vector3 playerRotateVector = Vector3.zero;
        float rotateValue = mouseDelta.x * rotateSpeed;

        if (inverseX)
            rotateValue *= -1;

        playerRotateVector = new Vector3(0f, rotateValue, 0f);

        transform.Rotate(playerRotateVector);
    }

    private void CameraRotate(Vector2 mouseDelta)
    {
        Vector3 cameraRotateVector = Vector3.zero;
        float rotateValue = mouseDelta.y * rotateSpeed;
        float currentRotate = playerCam.transform.eulerAngles.x;

        if (currentRotate >= 180f)
            currentRotate -= 360f;

        if (inverseY)
            rotateValue *= -1;

        rotateValue += currentRotate;
        rotateValue = Mathf.Clamp(rotateValue, minY, maxY);

        cameraRotateVector = new Vector3(rotateValue, 0f, 0f);

        playerCam.transform.localRotation = Quaternion.Euler(cameraRotateVector);
    }
}
