using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showdown : MonoBehaviour
{
    [SerializeField] private GameObject firstDomino;

    [Header("Initial push")]
    [SerializeField] private float torque = 10;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = firstDomino.GetComponent<Rigidbody>();
        rb.AddTorque(firstDomino.transform.right * torque);
    }
}
