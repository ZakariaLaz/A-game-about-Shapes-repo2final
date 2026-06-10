using UnityEngine;

public class LevelSelectStars : MonoBehaviour
{
    public GameObject level1_1Star;
    public GameObject level1_2Star;
    public GameObject level1_3Star;
    public GameObject level1_4Star;

    private void Start()
    {
        level1_1Star.SetActive(PlayerPrefs.GetInt("Level1-1_Cleared", 0) == 1);
        level1_2Star.SetActive(PlayerPrefs.GetInt("Level1-2_Cleared", 0) == 1);
        level1_3Star.SetActive(PlayerPrefs.GetInt("Level1-3_Cleared", 0) == 1);
        level1_4Star.SetActive(PlayerPrefs.GetInt("Level1-4_Cleared", 0) == 1);
    }
}