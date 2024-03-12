using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private PlayerFSM player;

    private void Awake()
    {
        player = transform.parent.GetComponent<PlayerFSM>();
    }
    private void AnimationEndTrigger()
    {
        player.AnimationEndTrigger();
    }
}
