using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    private Rigidbody rb;

    public GameManager gameManager;
    public List<GameObject> enemies;
    [Header("SFX")]
    public SoundEffects sfx;
    public PlayerSounds playerSfx;
    [Header("Particles")]
    public ParticleSystem goalBurst;
    public GameObject collisionParticle;
    public GameObject enemyCollisionParticle;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.linearVelocity.x > 0.15f || rb.linearVelocity.y > 0.15f || rb.linearVelocity.z > 0.15f)
        {
            playerSfx.RollingSound();
        } 
        else 
        {
            playerSfx.RollingSoundStop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            // Freeze player
            rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;

            if (enemies != null)
            {
                foreach (var enemy in enemies)
                {
                    Destroy(enemy);
                }
            }
            Invoke("NextLevel",0.3f);

            // Sound
            sfx.WinSound();

            // Particles
            goalBurst.Play();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            if (rb.linearVelocity.x > 0.4f || rb.linearVelocity.y > 0.4f || rb.linearVelocity.z > 0.4f)
            {
                playerSfx.Boing();

                // Particles
                Vector3 collisionPoint = collision.contacts[0].point;
                Vector3 collisionNormal = collision.contacts[0].normal;
                Vector3 spawnPosition = collisionPoint + collisionNormal * -0.2f;
                Quaternion rotation = Quaternion.LookRotation(collisionNormal);
                GameObject particleInstance = Instantiate(collisionParticle, spawnPosition, rotation);
                Destroy(particleInstance, 2f);

            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            sfx.FailSound();

            // Particles
            Vector3 collisionPoint = collision.contacts[0].point;
            Vector3 collisionNormal = collision.contacts[0].normal;
            Vector3 spawnPosition = collisionPoint + collisionNormal * -0.2f;
            Quaternion rotation = Quaternion.LookRotation(collisionNormal);
            GameObject particleInstance = Instantiate(enemyCollisionParticle, spawnPosition, rotation);
            Destroy(particleInstance, 2f);

            Invoke("ResetGame", 0.8f);
        }

        // Button
        if (collision.gameObject.CompareTag("Button"))
        {
            // Opens door
            var doorLogic = collision.gameObject.GetComponent<DoorController>();
            doorLogic.ButtonOpen();

            // Animation
            var animation = collision.gameObject.GetComponent<Animator>();
            animation.SetTrigger("Pushed");

            // Sound
            sfx.ButtonSound();

            collision.gameObject.tag = "Untagged"; // Can be clicked only once

        }

        // Switch
        if (collision.gameObject.CompareTag("Switch"))
        {
            // Opens door
            var doorLogic = collision.gameObject.GetComponent<DoorController>();
            doorLogic.DoorOpen();

            // Sound
            sfx.SwitchOnSound();
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

    private void ResetGame()
    {
        FindAnyObjectByType<GameManager>().GameOver();
    }

    private void NextLevel()
    {
        gameManager.LevelComplete();
    }
}
