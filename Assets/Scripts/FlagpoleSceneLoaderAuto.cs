using UnityEngine;
using UnityEngine.SceneManagement;

/*
This script is for automatically loading the next scene in
the Build settings when the flagpole is touched. Make
sure the scenes are in the right order.
*/


public class FlagpoleSceneLoaderAuto : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}