using UnityEngine;
using UnityEngine.UI;

public class SettingsUIConnector : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider brightnessSlider;

    private void Start()
    {
        SettingsMenu.Instance.ConnectSliders(volumeSlider, brightnessSlider);
    }
}
