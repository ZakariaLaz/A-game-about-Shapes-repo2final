using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public static SettingsMenu Instance;

    public Slider volumeSlider;
    public Slider brightnessSlider;
    public Image brightnessOverlay;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadSettings();
    }

    public void LoadSettings()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", 0f);

        ApplyVolume(savedVolume);
        ApplyBrightness(savedBrightness);

        if (volumeSlider != null)
            volumeSlider.SetValueWithoutNotify(savedVolume);

        if (brightnessSlider != null)
            brightnessSlider.SetValueWithoutNotify(savedBrightness);
    }

    public void ConnectSliders(Slider volume, Slider brightness)
    {
        volumeSlider = volume;
        brightnessSlider = brightness;

        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.RemoveAllListeners();
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        if (brightnessSlider != null)
        {
            brightnessSlider.onValueChanged.RemoveAllListeners();
            brightnessSlider.onValueChanged.AddListener(SetBrightness);
        }

        LoadSettings();
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
        ApplyVolume(volume);
    }

    public void SetBrightness(float brightness)
    {
        PlayerPrefs.SetFloat("Brightness", brightness);
        PlayerPrefs.Save();
        ApplyBrightness(brightness);
    }

    private void ApplyVolume(float volume)
    {
        AudioListener.volume = volume;
        Debug.Log("Volume set to: " + volume);
    }

    private void ApplyBrightness(float brightness)
    {
        if (brightnessOverlay != null)
        {
            brightnessOverlay.color = new Color(0, 0, 0, brightness);
        }
    }
}