using System;
using Cinemachine;
using UnityEngine;

public class Port : MonoBehaviour
{
    [SerializeField] PortInputSO input = null;
    [SerializeField] float rotateSpeed = 5f;

	private const int FOCUSED_PRIORITY = 20;
    private const int UNFOCUSED_PRIORITY = 1;

    private Transform focusPoint = null;
    private CinemachineVirtualCamera focusCam = null;
    private bool focused = false;
    private bool hold = false;

    private void Awake()
    {
        focusPoint = transform.Find("FocusPoint");
        focusCam = focusPoint.Find("FocusCam").GetComponent<CinemachineVirtualCamera>();

        input.OnRightClickedEvent += HandleRightClick;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Toggle();
            }
        }
    }

    private void FixedUpdate()
    {
        if(hold == false)
            return;

        Vector3 dir = new Vector3(-input.MouseDelta.y, input.MouseDelta.x, 0f) * Time.fixedDeltaTime * rotateSpeed;
        focusPoint.Rotate(dir);

        Vector3 euler = focusPoint.eulerAngles;
        if(euler.x >= 180f)
            euler.x -= 360f;
        euler.x = Mathf.Clamp(euler.x, -80f, 80f);
        euler.z = 0f;

        focusPoint.eulerAngles = euler;
    }

    private void OnDestroy()
    {
        input.OnRightClickedEvent -= HandleRightClick;
    }

    private void Toggle()
    {
        focused = !focused;
        focusCam.Priority = focused ? FOCUSED_PRIORITY : UNFOCUSED_PRIORITY;
        InputManager.ChangeInputMap(focused ? InputMapType.Port : InputMapType.Play);
    }

    private void HandleRightClick(bool active)
    {
        hold = active;
    }
}

