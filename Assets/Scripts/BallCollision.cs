using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject ball;
    [Header("SFX")]
    public SoundEffects sfx;
    public BallSounds playerSfx;
    [Header("Particles")]
    public GameObject particlePrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (rb.linearVelocity.x > 0.4f || rb.linearVelocity.y > 0.4f || rb.linearVelocity.z > 0.4f)
            {
                // Sound
                playerSfx.Boing();

                // Particles
                Vector3 collisionPoint = collision.contacts[0].point;
                Vector3 collisionNormal = collision.contacts[0].normal;
                Vector3 spawnPosition = collisionPoint + collisionNormal * -0.2f;
                Quaternion rotation = Quaternion.LookRotation(collisionNormal);
                GameObject particleInstance = Instantiate(particlePrefab, spawnPosition, rotation);
                Destroy(particleInstance, 2f);
            }
        }

        if (collision.gameObject.CompareTag("Button"))
        {
            var doorLogic = collision.gameObject.GetComponent<DoorController>();
            doorLogic.ButtonOpen();

            // Animation
            var animation = collision.gameObject.GetComponent<Animator>();
            animation.SetTrigger("Pushed");

            // Sound
            sfx.ButtonSound();

            collision.gameObject.tag = "Untagged";

        }
        
        if (collision.gameObject.CompareTag("Switch"))
        {
            // Animation
            var doorLogic = collision.gameObject.GetComponent<DoorController>();
            doorLogic.DoorOpen();

            // Sound
            sfx.SwitchOnSound();
        }
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Elimination"))
            {
                Destroy(ball);
            }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Switch"))
        {
            var doorLogic = collision.gameObject.GetComponent<DoorController>();
            doorLogic.DoorClose();

            // Sound
            sfx.SwitchOffSound();
        }
    }
}

