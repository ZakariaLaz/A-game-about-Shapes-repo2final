using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenFade : MonoBehaviour
{
    public static ScreenFade Instance;

    public Image fadeImage;
    public float fadeDuration = 1f;

    private bool isTransitioning = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        fadeImage.color = new Color(0, 0, 0, 0);
    }

    public void StartFadeToScene(int sceneIndex)
    {
        if (!isTransitioning)
        {
            StartCoroutine(FadeToScene(sceneIndex));
        }
    }

    private IEnumerator FadeToScene(int sceneIndex)
    {
        isTransitioning = true;

        yield return StartCoroutine(FadeOut());

        SceneManager.LoadScene(sceneIndex);

        yield return null;

        yield return StartCoroutine(FadeIn());

        isTransitioning = false;
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;
            float alpha = timer / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 1);
    }

    private IEnumerator FadeIn()
    {
        float timer = fadeDuration;

        while (timer > 0f)
        {
            timer -= Time.unscaledDeltaTime;
            float alpha = timer / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);
    }
}