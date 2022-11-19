using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCamera;
    [SerializeField] private CinemachineVirtualCamera fixedCamera;
    [SerializeField] private GameObject fallMenu;
    [SerializeField] private GameObject constructionMenu;
    [SerializeField] private GameObject path;


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
        fallMenu.SetActive(false);
    }

    public void SwitchToShowdownPhase()
    {
        path.GetComponentInChildren<LineRenderer>().enabled = false;
        constructionMenu.SetActive(false);
        fallMenu.SetActive(true);


        followCamera.Priority = 10;
        fixedCamera.Priority = 20;
    }

    public void TryAgain()
    {
        fader.TransitionToScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        fader.TransitionToScene(0);
    }
}
