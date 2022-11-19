using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCamera;
    [SerializeField] private CinemachineVirtualCamera fixedCamera;
    [SerializeField] private GameObject path;

    public static GameManager Instance;
    private void Awake()
    {
        Debug.Assert(Instance == null);
        Instance = this;
    }


    public void SwitchToShowdownPhase()
    {
        path.GetComponentInChildren<LineRenderer>().enabled = false;
        followCamera.Priority = 10;
        fixedCamera.Priority = 20;
    }
}
