using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCamera;
    [SerializeField] private CinemachineVirtualCamera fixedCamera;
    [SerializeField] private int mainMenuSceneIndex = 0;

    private Fader fader;

    public static GameManager Instance;
    private void Awake()
    {
        Debug.Assert(Instance == null);
        Instance = this;
    }

    private void Start()
    {
        fader = FindObjectOfType<Fader>();
    }

    public void SwitchToShowdownPhase()
    {
        followCamera.Priority = 10;
        fixedCamera.Priority = 20;
    }

    public void TryAgain()
    {
        fader.TransitionToScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        fader.TransitionToScene(mainMenuSceneIndex);
    }
}
