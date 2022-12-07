using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private List<Sprite> levels;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int currentLevel = 0;
    private int[] scores;

    private Fader fader;

    private void Start()
    {
        scores = new int[levels.Count];
        UpdateScores();

        fader = FindObjectOfType<Fader>();
        fader.FadeIn();
    }

    private void UpdateScores()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = PlayerPrefs.GetInt("level" + (i + 1).ToString(), 0);
        }
    }

    public void TransitionToScene(int id)
    {
        fader.TransitionToScene(id);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenLevelSelect()
    {
        currentLevel = 0;
        leftArrow.SetActive(false);
        UpdateUI();
    }

    public void ChangeLevel(int diff)
    {
        currentLevel += diff;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (currentLevel == 0) leftArrow.SetActive(false);
        else leftArrow.SetActive(true);

        if (currentLevel >= levels.Count - 1) rightArrow.SetActive(false);
        else rightArrow.SetActive(true);

        image.sprite = levels[currentLevel];
        scoreText.text = "Best: " + scores[currentLevel].ToString();
    }

    public void PlaySelectedLevel()
    {
        fader.TransitionToScene(currentLevel + 1);
    }

    public void ResetScores()
    {
        PlayerPrefs.DeleteAll();
        UpdateScores();
        UpdateUI();
    }
}
