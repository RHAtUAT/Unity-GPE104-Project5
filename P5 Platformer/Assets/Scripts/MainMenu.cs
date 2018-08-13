using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void LoadGame()
    {
        //Load the latest level played
        SceneManager.LoadScene(GameManager.instance.latestLevel);
        GameManager.instance.player.transform.position = GameManager.instance.startPosition;

    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
