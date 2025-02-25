using UnityEngine;

public class LevelFinished : MonoBehaviour
{
    public int levelIndex;

    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Player")
            {
                Debug.Log("Hit n run");
                PlayerPrefs.SetInt("Level_" + levelIndex, 1); // Mark level as completed
                PlayerPrefs.Save(); // Save progress
                Debug.Log("Level " + levelIndex + " Completed!");
            }
        }

    
}
