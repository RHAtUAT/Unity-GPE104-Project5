using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    //If player reaches/collides with the gameObject this script is attached to, they have completed the level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoadLevelCompletedScreen();
        }
    }

    public void LoadLevelCompletedScreen()
    {
        //If player completes the last level
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(6))
        {
            //Load the WinScene
            SceneManager.LoadScene(1);
        }
        else
            //Load the level completed Screen
            SceneManager.LoadScene(3);
    }
}
