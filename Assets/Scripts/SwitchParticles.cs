using UnityEngine;

public class SwitchParticles : MonoBehaviour
{
    public ParticleSystem particles;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            particles.Play();
        }
    }
}