using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] Transform placeParticleTransform;

    public void PlaceParticles()
    {
        if (particles)
        {
            Instantiate(particles, placeParticleTransform.position, placeParticleTransform.rotation);
        }
    }
}
