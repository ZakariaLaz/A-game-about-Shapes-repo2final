using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;

    public Image brightnessOverlay;
    public Slider brightnessSlider;

    private void Start()
    {
        volumeSlider.value = AudioListener.volume;

        brightnessSlider.value = brightnessOverlay.color.a;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void SetBrightness(float brightness)
    {
        Debug.Log("Brightness Changed: " + brightness);

        
        Color color = brightnessOverlay.color;

        color.a = brightness;

        brightnessOverlay.color = color;
    }
}
