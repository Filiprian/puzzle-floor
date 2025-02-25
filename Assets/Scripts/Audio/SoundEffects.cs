using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource src;
    public AudioClip winSFX, failSFX, buttonSFX, switchOnSFX, switchOffSFX;

    public void WinSound()
    {
        src.clip = winSFX;
        src.Play();
    }
    public void FailSound()
    {
        src.clip = failSFX;
        src.Play();
    }
    public void ButtonSound()
    {
        src.clip = buttonSFX;
        src.Play();
    }
    public void SwitchOnSound()
    {
        src.clip = switchOnSFX;
        src.Play();
    }
    public void SwitchOffSound()
    {
        src.clip = switchOffSFX;
        src.Play();
    }
}
