using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Level
{
    public int sceneId;
    public Sprite sprite;
}

public class MainMenu : MonoBehaviour
{
    Fader fader;
    [SerializeField] private List<Level> levels;
    [SerializeField] private GameObject leftArrow;
    [SerializeField] private GameObject rightArrow;
    [SerializeField] private Image image;
    private int currentLevelId = 0;
    private void Start()
    {
        fader = FindObjectOfType<Fader>();
        fader.FadeIn();
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
        currentLevelId = 0;
        leftArrow.SetActive(false);
        UpdateUI();
    }

    public void ChangeLevel(int diff)
    {
        currentLevelId += diff;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (currentLevelId == 0)
            leftArrow.SetActive(false);
        else
            leftArrow.SetActive(true);
        if (currentLevelId >= levels.Count - 1)
            rightArrow.SetActive(false);
        else
            rightArrow.SetActive(true);
        image.sprite = levels[currentLevelId].sprite;
    }

    public void PlaySelectedLevel()
    {
        fader.TransitionToScene(levels[currentLevelId].sceneId);
    }
}
