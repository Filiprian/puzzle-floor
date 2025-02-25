using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentMusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Scene Settings")]
    public int firstLevelIndex = 1; // Index of the first level scene in Build Settings

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // Persist across scenes
        audioSource = GetComponent<AudioSource>();

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the current scene index is a level
        if (scene.buildIndex >= firstLevelIndex+3)
        {
            Destroy(gameObject); // Destroy the MusicManager when entering a level
        }
    }
}
