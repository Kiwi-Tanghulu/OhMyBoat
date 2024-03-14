using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour, IInteractable
{
    [SerializeField] private Vector3 correctionValue;

    [SerializeField] private Transform ladderUpTrm;
    [SerializeField] private Transform ladderDownTrm;

    [SerializeField] private Transform upArriveTrm;
    [SerializeField] private Transform downArriveTrm;

    public bool Interact(Component performer, bool actived, Vector3 point = default)
    {
        if (actived == false)
            return false;

        PlayerMovement playerMovement = (performer as PlayerInteractor).Movement;
        playerMovement.SetClimingPos(ladderUpTrm.position, ladderDownTrm.position, upArriveTrm.position, downArriveTrm.position);

        float telePortPosY = Mathf.Lerp(ladderDownTrm.position.y, ladderUpTrm.position.y, point.y / ladderUpTrm.position.y);
        playerMovement.Teleport(new Vector3(transform.position.z, telePortPosY, transform.position.z) + correctionValue);

        return true;
    }
}
