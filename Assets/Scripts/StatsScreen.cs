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
        "Level1-4",
        "Level2-1",
        "Level2-2",
        "Level2-3",
        "Level2-4"
    };

    private void Start()
    {
        statsText.text = "FASTEST TIMES\n\n";

        foreach (string level in levels)
        {
            float bestTime = PlayerPrefs.GetFloat(level + "_BestTime", -1f);

            // Convert "Level1-1" to "Level 1-1"
            string displayName = level.Replace("Level", "Level ");

            if (bestTime < 0)
            {
                statsText.text += displayName + ": Not Completed\n";
            }
            else
            {
                int minutes = Mathf.FloorToInt(bestTime / 60);
                int seconds = Mathf.FloorToInt(bestTime % 60);

                statsText.text += displayName + ": " +
                                  minutes + ":" +
                                  seconds.ToString("00") + "\n";
            }
        }
    }
}