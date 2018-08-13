using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScene : MonoBehaviour {

    public void Retry()
    {
        //Reset values
        //load the level that the player was on
        SceneManager.LoadScene(GameManager.instance.latestLevel);
        GameManager.instance.player.transform.position = GameManager.instance.startPosition;
        GameManager.instance.playerLivesLeft = GameManager.instance.playerLivesAmount;

    }

    public void MainMenu()
    {
        //Reset values
        GameManager.instance.playerLivesLeft = GameManager.instance.playerLivesAmount;
        GameManager.instance.player.transform.position = GameManager.instance.mainmenuPos;
        SceneManager.LoadScene(0);

    }

}
