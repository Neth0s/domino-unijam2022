using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCamera;
    [SerializeField] private CinemachineVirtualCamera fixedCamera;
    [SerializeField] private GameObject fallMenu;
    [SerializeField] private GameObject constructionMenu;
    [SerializeField] private GameObject path;
    [SerializeField] private GameObject pauseMenu;
    
    [Header("Next Level")]
    [SerializeField] private bool lastLevel = false;

    [Header("End menu")]
    [SerializeField] private EndMenu endMenu;
    [SerializeField] private TMP_Text endMenuScore;
    [SerializeField] private TMP_Text endMenuDistance;
    [SerializeField] private ScoreResolver scoreResolver;

    [Header("Audio")]
    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] AudioSource audioSource;

    private bool gameEnded = false;
    private Fader fader;
    private Controls controls;

    public static GameManager Instance;
    
    private void Awake()
    {
        Debug.Assert(Instance == null);
        Instance = this;
        controls = controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Menu.Enable();
        controls.Menu.Pause.performed += ctx => TogglePause();
    }

    private void OnDisable()
    {
        controls.Menu.Disable();
        controls.Menu.Pause.performed += ctx => TogglePause();
    }
    private void Start()
    {
        fader = FindObjectOfType<Fader>();
        fallMenu.SetActive(false);
    }

    public void SwitchToShowdownPhase()
    {
        foreach (var line in path.GetComponentsInChildren<LineRenderer>()) line.enabled = false;

        audioSource.Stop();
        constructionMenu.SetActive(false);
        fallMenu.SetActive(true);

        followCamera.Priority = 10;
        fixedCamera.Priority = 20;
    }

    public void ShowEndMenu(int expressionIndex)
    {
        if (gameEnded) return;
        gameEnded = true;
        StartCoroutine(ShowEndMenuRoutine(expressionIndex));
    }

    private IEnumerator ShowEndMenuRoutine(int expressionIndex)
    {
        yield return new WaitForSeconds(.1f);
        
        endMenu.gameObject.SetActive(true);
        endMenu.ShowResult(expressionIndex);
        endMenuScore.SetText("Dorothy's happiness: " + (int)scoreResolver.Score);
        endMenuDistance.SetText("You made " + scoreResolver.TotalDistance.ToString("0.00") + "m of dominos!");
        
        audioSource.clip = audioClips[expressionIndex];
        audioSource.Play();

        fallMenu.SetActive(false);
    }

    public void TryAgain()
    {
        fader.TransitionToScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        if (lastLevel) fader.TransitionToScene(0);
        else fader.TransitionToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReturnToMainMenu()
    {
        fader.TransitionToScene(0);
    }

    public void TogglePause()
    {
        if (gameEnded) return;
        Time.timeScale = 1 - Time.timeScale;
        if (Time.timeScale < 1)
            pauseMenu.SetActive(true);
        else
            pauseMenu.SetActive(false);
    }
}
