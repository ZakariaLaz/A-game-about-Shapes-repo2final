using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    public GameObject victoryPanel;
    public TMP_Text timeText;

    private float levelTimer = 0f;
    private bool levelComplete = false;

    private void Start()
    {
        Time.timeScale = 1f;
        victoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (!levelComplete)
        {
            levelTimer += Time.deltaTime;
        }
    }

    public void ShowVictoryScreen()
    {
        levelComplete = true;

        int minutes = Mathf.FloorToInt(levelTimer / 60);
        int seconds = Mathf.FloorToInt(levelTimer % 60);

        timeText.text = "Time: " + minutes + ":" + seconds.ToString("00");

        victoryPanel.SetActive(true);
        Time.timeScale = 0f;

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Cleared", 1);
        PlayerPrefs.Save();

        Debug.Log("Saving completion for: " + SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        ScreenFade.Instance.StartFadeToScene(nextSceneIndex);
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level Select");
    }
}
