using UnityEngine;
using UnityEngine.SceneManagement;

/*
This script is for manually choosing which scene the
flagpole will load next in the Inspector.

Set the level in Next Scene in inspector
*/

public class FlagpoleSceneLoaderManual : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
