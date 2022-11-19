using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreResolver : MonoBehaviour
{
    [SerializeField] int score;

    [SerializeField] float clock = 0;
    [SerializeField] float maxTimeBetweenFalls = 1f;

    bool isResolving = false;

    private void OnEnable()
    {
        Domino.OnFall += HandleFall;
    }

    private void OnDisable()
    {
        Domino.OnFall -= HandleFall;
    }

    private void HandleFall(int index)
    {
        if (!isResolving) return;

        clock = maxTimeBetweenFalls;

        UpdateScore(index);
    }

    private void UpdateScore(int index)
    {

    }

    private void Update()
    {
        clock -= Time.deltaTime;

        if(isResolving && clock <= 0)
        {
            StopScoreResolution();
        }
    }

    public void StartScoreResolution()
    {
        isResolving = true;
    }

    private void StopScoreResolution()
    {
        isResolving = false;
    }
}
