using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DominoPoseDetection : MonoBehaviour
{
    [SerializeField] UnityEvent OnDominoPose;

    private void OnCollisionEnter(Collision collision)
    {
        OnDominoPose?.Invoke();
        Destroy(this);
    }
}
