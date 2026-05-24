using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public InputAction pauseAction;

    private void OnEnable()
    {
        pauseAction.Enable();
        pauseAction.performed += ctx => TogglePause();
    }

    private void OnDisable()
    {
        pauseAction.performed -= ctx => TogglePause();
        pauseAction.Disable();
    }

    void TogglePause()
    {
        if (pauseMenuUI.activeSelf)
            Resume();
        else
            Pause();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadTitleScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title Screen");
    }

    private void OnPause(InputAction.CallbackContext ctx)
{
    Debug.Log("Pause pressed");
    TogglePause();
}
}
