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
    
    [Header("Next Level")]
    [SerializeField] private int nextLevelIndex = 0;

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
        audioSource.Stop();
        path.GetComponentInChildren<LineRenderer>().enabled = false;
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
        endMenuScore.SetText("Dorothy's happiness: " + scoreResolver.Score);
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
        fader.TransitionToScene(nextLevelIndex);
    }

    public void ReturnToMainMenu()
    {
        fader.TransitionToScene(0);
    }
}
