using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    public AudioSource src;
    public AudioClip boing;

    public void Boing()
    {
        src.clip = boing;
        src.Play();
    }
}
