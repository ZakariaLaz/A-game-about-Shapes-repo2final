using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagpoleSceneLoaderAuto : MonoBehaviour
{
    private bool loadingScene = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Something touched the flagpole: " + other.name);

        if (loadingScene) return;

        if (other.CompareTag("Player"))
        {
            loadingScene = true;

            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            ScreenFade screenFade = FindFirstObjectByType<ScreenFade>();

            if (screenFade == null)
            {
                Debug.LogError("No ScreenFade object found in this scene!");
                SceneManager.LoadScene(nextSceneIndex);
                return;
            }

            Debug.Log("Flagpole touched. Starting fade.");
            screenFade.StartFadeToScene(nextSceneIndex);
        }
    }
}

