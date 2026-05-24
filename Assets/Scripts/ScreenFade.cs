using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenFade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        fadeImage.color = new Color(0, 0, 0, 0);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public IEnumerator FadeOut(int sceneIndex)
    {
        float timer = 0f;

        // Fade to black
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            float alpha = timer / fadeDuration;

            fadeImage.color = new Color(0, 0, 0, alpha);

            yield return null;
        }

        // Fully black
        fadeImage.color = new Color(0, 0, 0, 1);

        // Load scene
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float timer = fadeDuration;

        while (timer > 0f)
        {
            timer -= Time.deltaTime;

            float alpha = timer / fadeDuration;

            fadeImage.color = new Color(0, 0, 0, alpha);

            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}