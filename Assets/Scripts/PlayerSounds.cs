using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource src;
    public AudioClip rolling, boing;

    public void RollingSound()
    {
        if (!src.isPlaying)
        {
            src.clip = rolling;
            src.Play();
        }
    }
    public void RollingSoundStop()
    {
        if (src.isPlaying)
        {
            src.clip = rolling;
            src.Stop();
        }
    }
    public void Boing()
    {
        src.clip = boing;
        src.Play();
        Debug.Log("Boing");
    }
}
