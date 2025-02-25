using UnityEngine;
using UnityEngine.UI;

public class LevelFinishedManager : MonoBehaviour
{
    public Image[] levelCheckmarks;

    private void Start()
    {
        for (int i = 0; i < levelCheckmarks.Length; i++)
        {
            int levelNumber = i + 1; 
            if (PlayerPrefs.GetInt("Level_" + levelNumber, 0) == 1)
            {
                levelCheckmarks[i].gameObject.SetActive(true); // Show checkmark
            }
            else
            {
                levelCheckmarks[i].gameObject.SetActive(false); // Hide checkmark
            }
        }
    }
}
