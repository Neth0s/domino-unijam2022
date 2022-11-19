using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
class Result
{
    public Sprite sprite;
    public string text;
    public Color color;
}
public class EndMenu : MonoBehaviour
{
    [SerializeField] private List<Result> possibleResults;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image image;

    public void ShowResult(int resultIndex)
    {
        image.sprite = possibleResults[resultIndex].sprite;
        text.text = possibleResults[resultIndex].text;
        text.color = possibleResults[resultIndex].color;
    }
}
