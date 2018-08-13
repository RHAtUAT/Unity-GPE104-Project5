using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIElements : MonoBehaviour {

    //int i;
    //int tempLives;
	// Use this for initialization
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        GameManager.instance.playerLivesText.GetComponent<Text>().text = (" - " + GameManager.instance.playerLivesLeft.ToString());

        //Subtracting 3 because the first level starts at build index 4, the - 3 is an offset to make the levels number appear correctly in the game
        GameManager.instance.currentLevelText.GetComponent<Text>().text = (" Level - " + (GameManager.instance.latestLevel - 3).ToString()); 

        //If the active scene is the main menu, lose screen, win screen, or level completed scene dont display level or lives
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            GameManager.instance.playerLivesText.gameObject.SetActive(false);
            GameManager.instance.currentLevelText.gameObject.SetActive(false);
            GameManager.instance.playerLivesImage.gameObject.SetActive(false);
        }
        else
        {
            GameManager.instance.playerLivesText.gameObject.SetActive(true);
            GameManager.instance.currentLevelText.gameObject.SetActive(true);
            GameManager.instance.playerLivesImage.gameObject.SetActive(true);
        }


        //Dont display
        //string excludedScene = GameManager.instance.sceneExclusionList[i];
        //if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(excludedScene))
        //{
        //    GameManager.instance.playerLivesText.gameObject.SetActive(true);
        //    GameManager.instance.playerLivesImage.enabled = true;
        //    GameManager.instance.playerLivesText.GetComponent<Text>().text = (" - " + GameManager.instance.playerLivesLeft.ToString() + "Element: " + GameManager.instance.sceneExclusionList.Count.ToString());

        //}
        //else
        //{
        //    if(SceneManager.activeSceneChanged())
        //    GameManager.instance.playerLivesText.gameObject.SetActive(false);
        //    GameManager.instance.playerLivesImage.enabled = false;
        //}
        //if (i == GameManager.instance.sceneExclusionList.Count - 1)
        //{
        //    i =  -1;
        //}
        //i++;


        //Dont display the life counter in these excluded scenes
        //This should do the exact same thing but use an additional loop while the method above uses FixedUpdate() to accomplish the foreach loop 
        //This is easier to read which is why I would use this instead, but it is only returning the last element for some reason  
        /* GameManager.instance.sceneExclusionList.ForEach(delegate (string excludedSceneName)
         {
             if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(excludedSceneName))
             {
                 GameManager.instance.playerLivesImage.enabled = true;
                 GameManager.instance.playerLivesText.gameObject.SetActive(true);
                 GameManager.instance.playerLivesText.GetComponent<Text>().text = (" - " + excludedSceneName);
                 //GameManager.instance.playerLivesText.GetComponent<Text>().text = (" - " + GameManager.instance.playerLivesLeft.ToString());
             }
             else
             {
                 GameManager.instance.playerLivesText.gameObject.SetActive(false);
                 GameManager.instance.playerLivesImage.enabled = false;
             }

         });*/



    }
}
