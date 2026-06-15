using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathPanel;

    private void Start()
    {
        Time.timeScale = 1f;
        deathPanel.SetActive(false);
    }

    public void ShowDeathScreen()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        ScreenFade.Instance.StartFadeToScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }
}
