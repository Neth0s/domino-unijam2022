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

    public static Action<int> OnFall;
    [SerializeField] UnityEvent OnFallUnityEvent;

    public bool HasFallen { get; private set; }

    public void Init(int index, float distance)
    {
        Index = index;
        Distance = distance;
    }

    private void Awake()
    {
        SetInitialPosition();
    }

    public void SetInitialPosition()
    {
        initialHeight = transform.position.y;
    }

    private void Update()
    {
        if(!HasFallen && CheckForFall())
        {
            HasFallen = true;
            OnFall?.Invoke(Index);
            OnFallUnityEvent?.Invoke();
        }
    }

    public bool CheckForFall()
    {
        return transform.position.y <= initialHeight - fallHeightThreshold;
    }
}
