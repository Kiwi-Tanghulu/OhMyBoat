using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    [SerializeField] private CinemachineVirtualCamera activeCam;
    [SerializeField] private int activeCamPriority = 10;
    [SerializeField] private int inactiveCamPriority = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeActiveCam(CinemachineVirtualCamera newCam)
    {
        if (activeCam != null)
            activeCam.Priority = inactiveCamPriority;
        activeCam = newCam;
        activeCam.Priority = activeCamPriority;
    }
}
