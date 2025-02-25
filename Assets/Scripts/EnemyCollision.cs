using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private Rigidbody rb;

    public GameManager gameManager;
    public GameObject enemy;
    [Header("SFX")]
    public SoundEffects sfx;
    public EnemySounds playerSfx;
    [Header("Particles")]
    public GameObject particlePrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Goal"))
            {
                // SFX
                sfx.FailSound();

                // Game over
                Destroy(collision.gameObject);
                Invoke("ResetGame", 0.5f);
            }

        if (collision.gameObject.CompareTag("Wall"))
        {
            if (rb.linearVelocity.x > 0.4f || rb.linearVelocity.y > 0.4f || rb.linearVelocity.z > 0.4f)
            {
                // SFX
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

            if (collision.gameObject.layer == LayerMask.NameToLayer("Elimination"))
            {
                Destroy(enemy);
            }
        }
        
    private void ResetGame()
    {
        FindAnyObjectByType<GameManager>().GameOver();
    }
}
