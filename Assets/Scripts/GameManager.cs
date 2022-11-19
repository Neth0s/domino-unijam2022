using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCamera;
    [SerializeField] private CinemachineVirtualCamera fixedCamera;

    public static GameManager Instance;
    private void Awake()
    {
        Debug.Assert(Instance == null);
        Instance = this;
    }


    public void SwitchToShowdownPhase()
    {
        followCamera.Priority = 10;
        fixedCamera.Priority = 20;
    }
}
