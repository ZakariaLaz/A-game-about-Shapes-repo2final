using UnityEngine;

public class FlagpoleSceneLoaderManual : MonoBehaviour
{
    private bool levelFinished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (levelFinished) return;

        if (other.CompareTag("Player"))
        {
            levelFinished = true;
            FindFirstObjectByType<VictoryScreen>().ShowVictoryScreen();
        }
    }
}
