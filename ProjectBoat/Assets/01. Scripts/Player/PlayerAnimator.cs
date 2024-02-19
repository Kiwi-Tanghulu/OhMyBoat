using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;

    private int moveXHash = Animator.StringToHash("move_x");
    private int moveYHash = Animator.StringToHash("move_y");
    private int jumpHash = Animator.StringToHash("is_jump");

    [SerializeField] private float moveTransitionSpeed;

    [Space]
    [SerializeField] private PlayInputSO inputSO;

    private Vector2 moveDir;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        inputSO.OnMoveEvent += PlayInput_OnMoveEvent;
    }

    private void OnDestroy()
    {
        inputSO.OnMoveEvent -= PlayInput_OnMoveEvent;
    }

    private void Update()
    {
        SetMoveAnim();
    }

    private void PlayInput_OnMoveEvent(Vector2 value)
    {
        moveDir = value;
    }

    private void SetMoveAnim()
    {
        float xHash = anim.GetFloat(moveXHash);
        float yHash = anim.GetFloat(moveYHash);
        float x;
        float y;

        if (MathF.Abs(xHash - moveDir.x) < 0.01f)
        {
            x = moveDir.x;
        }
        else
        {
            x = Mathf.Lerp(xHash, moveDir.x, Time.deltaTime * moveTransitionSpeed);
        }

        if (MathF.Abs(yHash - moveDir.y) < 0.01f)
        {
            y = moveDir.y;
        }
        else
        {
            y = Mathf.Lerp(yHash, moveDir.y, Time.deltaTime * moveTransitionSpeed);
        }

        anim.SetFloat(moveXHash, x);
        anim.SetFloat(moveYHash, y);
    }

    public void SetJumpAnim(bool value)
    {
        anim.SetBool(jumpHash, value);
    }
}
