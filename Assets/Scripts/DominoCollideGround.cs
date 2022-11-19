using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoCollideGround : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Domino"))
        {
            audioSource.Play();
            Destroy(this);
        }
    }
}
