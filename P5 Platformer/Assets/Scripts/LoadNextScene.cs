using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour {

    public void LoadNextLevel()
    {
        //Load the next the level
        SceneManager.LoadScene(GameManager.instance.latestLevel + 1);
        GameManager.instance.player.transform.position = GameManager.instance.startPosition;
        GameManager.instance.playerLivesLeft = GameManager.instance.playerLivesAmount;
    }

    public void Restart()
    {
        SceneManager.LoadScene(4);
        GameManager.instance.player.transform.position = GameManager.instance.startPosition;
        GameManager.instance.playerLivesLeft = GameManager.instance.playerLivesAmount;
    }


}
