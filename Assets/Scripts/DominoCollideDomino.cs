using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoCollideDomino : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] List<AudioClip> audioClips;

    [SerializeField] AnimationCurve pitchCurve;
    [SerializeField] float pitchCoefficientIncrement = 0.02f;
    public static float PitchCoefficient;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Domino"))
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Count - 1)];
            PitchCoefficient += pitchCoefficientIncrement;
            audioSource.pitch = pitchCurve.Evaluate(PitchCoefficient);
            audioSource.Play();
            Destroy(this);
        }
    }
}

