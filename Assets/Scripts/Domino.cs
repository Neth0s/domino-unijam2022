using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Domino : MonoBehaviour
{
    [SerializeField] float fallHeightThreshold = 0.01f;
    [SerializeField] UnityEvent OnFallUnityEvent;

    public static Action<Domino> OnFall;

    public int Index { get; private set; }
    public float Distance { get; private set; }
    public bool HasFallen { get; private set; }
    public bool HasGoodColor { get; private set; }

    float normalizedDistance;
    float initialHeight;

    PathDrawer pathDrawer;
    Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void Init(int index, float distance, float normalizedDistance, PathDrawer pathDrawer)
    {
        Index = index;
        Distance = distance;
        this.normalizedDistance = normalizedDistance;
        this.pathDrawer = pathDrawer;
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
            HasFallen = true;
            OnFall?.Invoke(this);
            OnFallUnityEvent?.Invoke();
        }
    }

    public bool CheckForFall()
    {
        return transform.position.y <= initialHeight - fallHeightThreshold;
    }

    public void CheckForColor()
    {
        Color expectedColor = pathDrawer.Evaluate(normalizedDistance);

        HasGoodColor = rend.material.color.r == expectedColor.r
                    && rend.material.color.g == expectedColor.g
                    && rend.material.color.b == expectedColor.b;
    }
}
