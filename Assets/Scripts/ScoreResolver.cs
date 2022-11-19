using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreResolver : MonoBehaviour
{
    [SerializeField] float score;

    [SerializeField] float clock = 0;
    [SerializeField] float maxTimeBetweenFalls = 1f;

    [SerializeField] float multiplicativeCoefficientOnFault = 0.5f;

    [SerializeField] GameObject dominosParent;
    [SerializeField] float showdownTorque = 100f;

    static public Action OnStartScoreResolution;

    bool[] fallenDominosTags;

    [SerializeField] TMP_Text scoreText;


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
            OnRightDominoFall(distanceDelta);
        }
        else
        {
            OnBadDominoFall();
        }

        Debug.Log("Score: " + score.ToString() + " Current Distance Combo: " + currentDistanceCombo.ToString());

        lastDominoIndex = domino.Index;
    }

    private void OnRightDominoFall(float distanceDelta)
    {
        Debug.Log("Right domino has fallen");
        if(currentDistanceCombo != 0f)
        {
            score += distanceDelta;
        }
        currentDistanceCombo += distanceDelta;
    }

    private void OnBadDominoFall()
    {
        Debug.Log("Bad domino has fallen");
        currentDistanceCombo = 0f;
        score *= multiplicativeCoefficientOnFault;
    }

    private void Update()
    {
        if(isResolving)
        {
            clock -= Time.deltaTime;

            if (clock <= 0)
            {
                Debug.Log("Time out, check if there is still a domino to fall");
                CheckIfThereIsStillADominoToFall();
            }
        }

        scoreText.text = score.ToString();
    }

    public void StartScoreResolution()
    {
        isResolving = true;
        fallenDominosTags = new bool[dominosParent.transform.childCount];
        clock = maxTimeBetweenFalls;

        Showdown(0);

        OnStartScoreResolution();
    }

    private void CheckIfThereIsStillADominoToFall()
    {
        for (int i = 0; i < fallenDominosTags.Length; i++)
        {
            if(fallenDominosTags[i] == false)
            {
                score *= multiplicativeCoefficientOnFault;
                clock = maxTimeBetweenFalls;
                Debug.Log("Found domino " + i.ToString() + " that can fall. Fault.");
                Debug.Log("Score: " + score.ToString());
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
        Debug.Log("Stop score resolution");
        Debug.Log("Final score: " + score.ToString());
    }

    private void Showdown(int index)
    {
        var dominoToShowdown = dominosParent.transform.GetChild(index);
        dominoToShowdown.GetComponent<Rigidbody>().AddTorque(dominoToShowdown.right * showdownTorque);
    }
}
