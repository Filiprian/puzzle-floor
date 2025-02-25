using UnityEngine;

public class ButtonParticles : MonoBehaviour
{
    public ParticleSystem particles;

    private bool neverTouched = true;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (neverTouched)
            {
                particles.Play();
                neverTouched = false;
                Debug.Log(neverTouched);
            }

        }
    }
}
