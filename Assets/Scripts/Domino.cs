using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Domino : MonoBehaviour
{
    public int Index { get; private set; }
    public float Distance { get; private set; }

    float normalizedDistance;

    [SerializeField] float fallHeightThreshold = 0.01f;
    float initialHeight;

    public static Action<Domino> OnFall;
    [SerializeField] UnityEvent OnFallUnityEvent;

    public bool HasFallen { get; private set; }

    PathDrawer pathDrawer;

    public bool HasGoodColor { get; private set; }

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
        Cinemachine.CinemachineTrackedDolly dolly;
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
        Debug.Log("Color checked " + HasGoodColor.ToString());
    }
}
