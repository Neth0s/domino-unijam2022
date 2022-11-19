using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreResolver : MonoBehaviour
{
    [Header("Dependancies")]
    [SerializeField] GameObject dominosParent;
    [SerializeField] GameObject button;
    [SerializeField] TMP_Text scoreText;

    [Header ("Parameters")]
    [SerializeField] float maxTimeBetweenFalls = 1f;
    [SerializeField] float errorScoreMultiplier = 0.5f;
    [SerializeField] float showdownTorque = 100f;

    static public Action OnStartScoreResolution;

    bool[] fallenDominosTags;

    private float score;
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
            float distanceDelta = domino.Distance - lastDistance;
            OnCorrectDominoFall(distanceDelta);
        }
        else OnBadDominoFall();

        lastDominoIndex = domino.Index;
    }

    private void OnCorrectDominoFall(float distanceDelta)
    {
        if(currentDistanceCombo != 0f) score += distanceDelta;
        currentDistanceCombo += distanceDelta;
    }

    private void OnBadDominoFall()
    {
        Debug.Log("Bad domino fall, combo interrupted.");
        currentDistanceCombo = 0f;
        score *= errorScoreMultiplier;
    }

    private void CheckDominoLeftToFall()
    {
        for (int i = 0; i < fallenDominosTags.Length; i++)
        {
            if(!fallenDominosTags[i])
            {
                score *= errorScoreMultiplier;
                clock = maxTimeBetweenFalls;
                currentDistanceCombo = 0f;

                Showdown(i);
                return;
            }
        }

        StopScoreResolution();
    }

    private void StopScoreResolution()
    {
        isResolving = false;
    }

    private void Showdown(int index)
    {
        var dominoToShowdown = dominosParent.transform.GetChild(index);
        dominoToShowdown.GetComponent<Rigidbody>().AddTorque(dominoToShowdown.right * showdownTorque);
    }
}
