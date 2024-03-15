using System;
using Cinemachine;
using UnityEngine;

public class Port : MonoBehaviour
{
    [SerializeField] UIInputSO input = null;
    [SerializeField] float rotateSpeed = 5f;
    [SerializeField] float zoomSpeed = 5f;
    [SerializeField] Vector2 zoomClamp = new Vector2(1f, 50f);

	private const int FOCUSED_PRIORITY = 20;
    private const int UNFOCUSED_PRIORITY = 1;

    private Transform focusPoint = null;
    private CinemachineVirtualCamera focusCam = null;
    private bool focused = false;

    private void Awake()
    {
        focusPoint = transform.Find("FocusPoint");
        focusCam = focusPoint.Find("FocusCam").GetComponent<CinemachineVirtualCamera>();

        input.OnEscapeEvent += HandleEscape;
        input.OnScrollEvent += HandleScroll;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Toggle(true);
            }
        }
    }

    private void FixedUpdate()
    {
        if(focused == false)
            return;

        focusPoint.Rotate(Vector3.up, -rotateSpeed * Time.fixedDeltaTime);
    }

    private void Toggle(bool value)
    {
        focused = value;
        focusCam.Priority = focused ? FOCUSED_PRIORITY : UNFOCUSED_PRIORITY;
        InputManager.ChangeInputMap(focused ? InputMapType.UI : InputMapType.Play);
    }

    private void HandleEscape()
    {
        Toggle(false);
    }

    private void HandleScroll(float delta)
    {
        Vector3 localPosition = focusCam.transform.localPosition;
        localPosition.z += delta * zoomSpeed * Time.deltaTime;
        localPosition.z = Mathf.Clamp(localPosition.z, zoomClamp.x, zoomClamp.y);

        focusCam.transform.localPosition = localPosition;
    }
}

