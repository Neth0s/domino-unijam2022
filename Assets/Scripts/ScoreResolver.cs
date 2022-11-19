using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreResolver : MonoBehaviour
{
    [SerializeField] float score;

    [SerializeField] float clock = 0;
    [SerializeField] float maxTimeBetweenFalls = 1f;

    static public Action OnStartScoreResolution;

    bool isResolving = false;

    int lastDominoIndex = -1;
    float lastDistance = 0f;
    float currentDistanceCombo = 0f;

    private void Awake()
    {
        StartScoreResolution();
    }

    private void OnEnable()
    {
        Domino.OnFall += HandleFall;
    }

    private void OnDisable()
    {
        Domino.OnFall -= HandleFall;
    }

    private void HandleFall(Domino domino)
    {
        if (!isResolving) return;

        clock = maxTimeBetweenFalls;

        UpdateScore(domino);
    }

    private void UpdateScore(Domino domino)
    {
        if(domino.Index == lastDominoIndex + 1)
        {
            float distanceDelta = domino.Distance - lastDistance;
            OnRightDominoFall(distanceDelta);
        }
        else
        {
            OnBadDominoFall();
        }

        Debug.Log("Score: " + score.ToString() + " Current Distance Combo: " + currentDistanceCombo.ToString());

        lastDominoIndex = domino.Index;
    }

    private void OnBadDominoFall()
    {
        currentDistanceCombo = 0f;
    }

    private void OnRightDominoFall(float distanceDelta)
    {
        currentDistanceCombo = distanceDelta;
        score += distanceDelta;
    }

    private void Update()
    {
        if(isResolving)
        {
            clock -= Time.deltaTime;

            if (clock <= 0)
            {
                StopScoreResolution();
            }
        }
    }

    public void StartScoreResolution()
    {
        isResolving = true;

        OnStartScoreResolution();
    }

    private void StopScoreResolution()
    {
        isResolving = false;
    }
}
