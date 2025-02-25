using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsLogic : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    private const string VolumeKey = "GameVolume";

    void Start()
    {
        // Load saved volume
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 0);
        audioMixer.SetFloat("volume", savedVolume);

        // Set visualy slidebar again
        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
        }
    }

    // Volume changer
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat(VolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
