using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitions : MonoBehaviour
{
    public Animator transition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Removes checkmarks
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

            LoadMenu();
        }
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadLevel(1));
    }
    public void LoadSettings()
    {
        StartCoroutine(LoadLevel(2));
    }
    public void LoadLevelSelect()
    {
        StartCoroutine(LoadLevel(3));
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }
}
