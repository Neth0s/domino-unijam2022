using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] Transform placeParticleTransform;
    [SerializeField] ParticleSystem collisionParticles;
    public void PlaceParticles()
    {
        if (particles)
        {
            Instantiate(particles, placeParticleTransform.position, placeParticleTransform.rotation);
        }
    }

    public void CollislionParticles(Vector3 pos)
    {
        if (collisionParticles)
        {
            Instantiate(collisionParticles, placeParticleTransform.position, placeParticleTransform.rotation);
        }
    }
}
