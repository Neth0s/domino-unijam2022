using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Domino : MonoBehaviour
{
    public int Index { get; private set; }
    public float Distance { get; private set; }

    [SerializeField] float fallHeightThreshold = 0.01f;
    float initialHeight;

    public static Action<Domino> OnFall;
    [SerializeField] UnityEvent OnFallUnityEvent;

    public bool HasFallen { get; private set; }

    public void Init(int index, float distance)
    {
        Index = index;
        Distance = distance;
    }

    private void OnEnable()
    {
        ScoreResolver.OnStartScoreResolution += HandleStartScoreResolution;
    }

    private void OnDisable()
    {
        ScoreResolver.OnStartScoreResolution -= HandleStartScoreResolution;
    }

    public void SetInitialPosition()
    {
        initialHeight = transform.position.y;
    }

    public void HandleStartScoreResolution()
    {
        SetInitialPosition();
    }

    private void Update()
    {
        if(!HasFallen && CheckForFall())
        {
            Debug.Log("OnFall");
            HasFallen = true;
            OnFall?.Invoke(this);
            OnFallUnityEvent?.Invoke();
        }
    }

    public bool CheckForFall()
    {
        return transform.position.y <= initialHeight - fallHeightThreshold;
    }
}
