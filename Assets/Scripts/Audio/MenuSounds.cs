using UnityEngine;
using UnityEngine.Audio;

public class MenuSounds : MonoBehaviour
{
    public AudioSource src;
    public AudioClip hover, clicked;

    public void ButtonClicked()
    {
        src.clip = clicked;
        src.Play();
    }

    public void Hover()
    {
        src.clip = hover;
        src.Play();
    }
}
