using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoCollideDomino : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceCrisp;
    [SerializeField] AudioSource audioSourcePitch;

    [SerializeField] List<AudioClip> audioClips;

    [SerializeField] AnimationCurve pitchCurve;
    [SerializeField] float pitchCoefficientIncrement = 0.02f;
    public static float PitchCoefficient;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Domino"))
        {
            PitchCoefficient += pitchCoefficientIncrement;
            audioSourcePitch.pitch = 0.8f + pitchCurve.Evaluate(PitchCoefficient);
            audioSourcePitch.Play();

            audioSourceCrisp.clip = audioClips[Random.Range(0, audioClips.Count - 1)];
            audioSourceCrisp.Play();

            Destroy(this);
        }
    }
}

