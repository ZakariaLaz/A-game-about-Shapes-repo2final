using UnityEngine;

public class LevelSelectStars : MonoBehaviour
{
    public GameObject level1_1Star;
    public GameObject level1_2Star;
    public GameObject level1_3Star;
    public GameObject level1_4Star;

    public GameObject level2_1Star;
    public GameObject level2_2Star;
    public GameObject level2_3Star;
    public GameObject level2_4Star;

    public GameObject completeGraphic;

    private void Start()
    {
        bool level1_1Cleared = PlayerPrefs.GetInt("Level1-1_Cleared", 0) == 1;
        bool level1_2Cleared = PlayerPrefs.GetInt("Level1-2_Cleared", 0) == 1;
        bool level1_3Cleared = PlayerPrefs.GetInt("Level1-3_Cleared", 0) == 1;
        bool level1_4Cleared = PlayerPrefs.GetInt("Level1-4_Cleared", 0) == 1;

        bool level2_1Cleared = PlayerPrefs.GetInt("Level2-1_Cleared", 0) == 1;
        bool level2_2Cleared = PlayerPrefs.GetInt("Level2-2_Cleared", 0) == 1;
        bool level2_3Cleared = PlayerPrefs.GetInt("Level2-3_Cleared", 0) == 1;
        bool level2_4Cleared = PlayerPrefs.GetInt("Level2-4_Cleared", 0) == 1;

        level1_1Star.SetActive(level1_1Cleared);
        level1_2Star.SetActive(level1_2Cleared);
        level1_3Star.SetActive(level1_3Cleared);
        level1_4Star.SetActive(level1_4Cleared);

        level2_1Star.SetActive(level2_1Cleared);
        level2_2Star.SetActive(level2_2Cleared);
        level2_3Star.SetActive(level2_3Cleared);
        level2_4Star.SetActive(level2_4Cleared);

        completeGraphic.SetActive(
            level1_1Cleared &&
            level1_2Cleared &&
            level1_3Cleared &&
            level1_4Cleared &&
            level2_1Cleared &&
            level2_2Cleared &&
            level2_3Cleared &&
            level2_4Cleared
        );
    }
}