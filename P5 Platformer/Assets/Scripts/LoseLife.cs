using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseLife : MonoBehaviour {

    //If the GameObject this script is attached to collides with a gameobject of tag DeathBarrier, make the player lose a life
    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "DeathBarrier")
        {
            LoseALife();
        }
    }

    //Return the amount of lives the player has so that the playerLivesText  on screen text shows the correct amount
	public int LoseALife()
    {

        //If the active scene is not the main menu
        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(0))
        {
            GameManager.instance.playerLivesLeft--;
        }
        if(GameManager.instance.playerLivesLeft == 0)
        {
            //Load the Lose Scene if the player runs out of lives
            SceneManager.LoadScene(2);
        }
        //If no checkpoint has been passed, the player respawns at the start position
		if (GameManager.instance.currentCheckPoint == null) 
		{
			GameManager.instance.player.transform.position = GameManager.instance.startPosition;
		} 
		else 
		{
			GameManager.instance.player.transform.position = GameManager.instance.currentCheckPoint.transform.position;
		}
        return GameManager.instance.playerLivesLeft;
    }
}
