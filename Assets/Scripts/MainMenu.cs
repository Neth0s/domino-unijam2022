using UnityEngine;

public class MainMenu : MonoBehaviour
{
    Fader fader;

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
}
