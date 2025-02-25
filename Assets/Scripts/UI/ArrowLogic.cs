using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LevelSelector : MonoBehaviour
{
    public Button nextArrow;
    public Button backArrow;
    public Button Play;
    public Animator transition;
    public Button[] levelButtons;
    public Image[] levelImages;
    public TMP_Text[] levelNames;
    
    public Color normalColor = Color.white;
    public Color highlightedColor = Color.yellow;

    private int levelSelected = 1;

    void Start()
    {
        // Calls function when clicked
        nextArrow.onClick.AddListener(() => OnArrowClick(true));
        backArrow.onClick.AddListener(() => OnArrowClick(false));
        Play.onClick.AddListener(() => PlaySelectedLevel());

        UpdateButtonHighlight();
        UpdateLevelPreview();
    }

    public void OnArrowClick(bool isNext)
    {
        if (isNext)
        {
            levelSelected = (levelSelected % 16) + 1; // Loop from 1 to 16
        }
        else
        {
            levelSelected = (levelSelected == 1) ? 16 : levelSelected - 1; // Loop from 16 to 1
        }

        UpdateButtonHighlight();
        UpdateLevelPreview();
    }

    private void UpdateButtonHighlight()
    {
        // Reset all buttons to normal color
        foreach (Button button in levelButtons)
        {
            button.GetComponent<Image>().color = normalColor;
        }

        // Highlight the selected button
        levelButtons[levelSelected - 1].GetComponent<Image>().color = highlightedColor;
    }

    private void UpdateLevelPreview()
    {
        // Hide all level images and names
        foreach (Image img in levelImages)
        {
            img.gameObject.SetActive(false);
        }
        foreach (TMP_Text txt in levelNames)
        {
            txt.gameObject.SetActive(false);
        }

        // Show only the selected level's image and name
        levelImages[levelSelected - 1].gameObject.SetActive(true);
        levelNames[levelSelected - 1].gameObject.SetActive(true);
    }

    public void PlaySelectedLevel()
    {
        string sceneName = "Level" + levelSelected;
        StartCoroutine(LoadLevel(sceneName));
    }

    IEnumerator LoadLevel(string sceneName) 
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }
}
