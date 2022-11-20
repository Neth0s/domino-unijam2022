using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreResolver : MonoBehaviour
{
    [Header("Dependancies")]
    [SerializeField] GameObject dominosParent;
    [SerializeField] GameObject button;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] Image girlExpressionImage;

    [Header ("Parameters")]
    [SerializeField] float maxTimeBetweenFalls = 1f;
    [SerializeField] float scoreMultiplier = 10f;
    [SerializeField] float errorScoreMultiplier = 0.5f;
    [SerializeField] float showdownTorque = 100f;
    [SerializeField] Vector4 expressionThreshold = new(10, 20, 30, 40);
    [SerializeField] private List<Sprite> faceExpressions;

    static public Action OnStartScoreResolution;

    bool[] fallenDominosTags;

    private float score = 0;
    private float errors = 0;
    private float clock = 0;

    bool isResolving = false;

    int lastDominoIndex = -1;
    float lastDistance = 0f;
    float currentDistanceCombo = 0f;

    private void OnEnable()
    {
        Domino.OnFall += HandleFall;
    }

    private void OnDisable()
    {
        Domino.OnFall -= HandleFall;
    }

    private void Update()
    {
        if (isResolving)
        {
            clock -= Time.deltaTime;
            if (clock <= 0) CheckDominoLeftToFall();
        }

        scoreText.text = ((int)score).ToString();
    }

    public void StartScoreResolution()
    {
        button.SetActive(false);
        scoreText.gameObject.SetActive(true);

        DominoCollideDomino.PitchCoefficient = 0;
        isResolving = true;
        fallenDominosTags = new bool[dominosParent.transform.childCount];
        clock = maxTimeBetweenFalls;

        Showdown(0);

        OnStartScoreResolution();
    }

    private void HandleFall(Domino domino)
    {
        if (!isResolving) return;

        clock = maxTimeBetweenFalls;
        fallenDominosTags[domino.Index] = true;

        UpdateScore(domino);
    }

    private void UpdateScore(Domino domino)
    {
        if(domino.Index == lastDominoIndex + 1)
        {
            if (domino.HasGoodColor)
                OnCorrectFall(domino);
            else OnWrongColor(domino);
        }
        else OnBadFall();

        lastDominoIndex = domino.Index;

        girlExpressionImage.sprite = faceExpressions[getExpressionIndex()];
    }

    private int getExpressionIndex()
    {
        if (score < expressionThreshold.x)
            return 0;
        else if (score < expressionThreshold.y)
            return 1;
        else if (score < expressionThreshold.z)
            return 2;
        else if (score < expressionThreshold.w)
            return 3;
        else
            return 4;
    }

    private void OnCorrectFall(Domino domino)
    {
        float distanceDelta = domino.Distance - lastDistance;
        if (currentDistanceCombo != 0f) score += scoreMultiplier * distanceDelta;
        currentDistanceCombo += distanceDelta;
    }

    private void OnWrongColor(Domino domino)
    {
        currentDistanceCombo = 0f;
        DominoCollideDomino.PitchCoefficient = 0;
        Debug.Log("Wrong color");
    }

    private void OnBadFall()
    {
        currentDistanceCombo = 0f;
        score *= errorScoreMultiplier;
        Debug.Log("Bad fall");

        DominoCollideDomino.PitchCoefficient = 0;
        lastDominoIndex++;
        errors++;
        if (errors == 3) StopScoreResolution();
    }

    private void CheckDominoLeftToFall()
    {
        for (int i = 0; i < fallenDominosTags.Length; i++)
        {
            if(!fallenDominosTags[i])
            {
                clock = maxTimeBetweenFalls;
                OnBadFall();

                Showdown(i);
                return;
            }
        }

        StopScoreResolution();
    }

    private void StopScoreResolution()
    {
        isResolving = false;
        GameManager.Instance.ShowEndMenu(getExpressionIndex());
    }

    private void Showdown(int index)
    {
        var dominoToShowdown = dominosParent.transform.GetChild(index);
        dominoToShowdown.GetComponent<Rigidbody>().AddTorque(dominoToShowdown.right * showdownTorque);
    }
}
