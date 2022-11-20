using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConstructionMenu : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> dominoKeyTexts;
    [SerializeField] private List<TextMeshProUGUI> dominosCountsTexts;
    [SerializeField] private List<Color> dominoColors;

    void Start()
    {
        for (int i = 0; i < dominoKeyTexts.Count; i++)
        {
            dominoKeyTexts[i].color = dominoColors[i];
            dominosCountsTexts[i].color = dominoColors[i];
        }
    }
}
