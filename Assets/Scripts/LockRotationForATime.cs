using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotationForATime : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] float time = .5f;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void CollisionHandler()
    {
        Invoke("Unlock", time);
    }

    public void Unlock()
    {
        body.constraints = RigidbodyConstraints.None;
    }
}
