using UnityEngine;
using TMPro;

public class StatsScreen : MonoBehaviour
{
    public TMP_Text statsText;

    private string[] levels =
    {
        "Level1-1",
        "Level1-2",
        "Level1-3",
        "Level1-4"
    };

    private void Start()
    {
        statsText.text = "Fastest Times\n\n";

        foreach (string level in levels)
        {
            float bestTime = PlayerPrefs.GetFloat(level + "_BestTime", -1f);

            if (bestTime < 0)
            {
                statsText.text += level + ": Not completed\n";
            }
            else
            {
                int minutes = Mathf.FloorToInt(bestTime / 60);
                int seconds = Mathf.FloorToInt(bestTime % 60);

                statsText.text += level + ": " + minutes + ":" + seconds.ToString("00") + "\n";
            }
        }
    }
}
