using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    //Level art
    //https://opengameart.org/content/free-desert-platformer-tileset
    //https://opengameart.org/content/platformer-art-deluxe

    //Music
    //https://www.youtube.com/watch?v=3nlSDxvt6JU

    //Jump Sound
    //https://opengameart.org/content/platformer-jumping-sounds


    //Player
    [Header("Player")]
    public GameObject player;
    public float playerSpeed;
    public float playerJumpVelocity;
    public int playerJumpAmount;
    public int playerJumpsRemaining;
    public float raycastOffset;
    public bool isGrounded;
    public int playerLivesAmount;
    public int playerLivesLeft;

    //Camera
    [Header("Camera")]
    public float cameraXMax;
    public float cameraYMax;
    public float cameraXMin;
    public float cameraYMin;
    public float yOffset;
    public float xOffset;

    //Audio
    [Header("Audio")]
    public AudioSource gameMusic;
    public AudioSource playerJumpSound;

    //UI elements
    [Header("UI Elements")]
    public Text playerLivesText;
    public Image playerLivesImage;
    public Text currentLevelText;
    [Tooltip("Enter the names of scenes to exclude the Lives UI elements from")]
    public List<string> sceneExclusionList;

    //Level
    [Header("Level")]
    //LocationPoints
	public Vector3 startPosition;
    public GameObject currentCheckPoint;
	public List<GameObject> checkPoint;
    public int latestLevel;
    public Vector3 mainmenuPos;

    //DeathBarriers
    public List<GameObject> deathBarriers;

    // Use this for initialization
    void Awake ()
    {
        mainmenuPos = new Vector3(-43.8f, -27.53f, 0);
        if (latestLevel == 0)
        {
            latestLevel = 4;
        }
        sceneExclusionList.Add("MainMenu");
        sceneExclusionList.Add("LoseScene");
        playerLivesLeft = playerLivesAmount;

        //Only allow one instance of this GameManager to exist
        //Dont destroy this GameObject when new scenes are loaded
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Add the death barriers in the current scene to the DeathBarriers List
        if(deathBarriers.Count == 0)
        {
            deathBarriers.AddRange(GameObject.FindGameObjectsWithTag("DeathBarrier"));
        }

        GetLatestLevel();
        TogglePlayerVisibility();
        RemoveDestroyedCheckpoints();
        RemoveDestroyedDeathBarriers();
        RemoveCheckpoints();
        ToggleMusic();
	}

    void ToggleMusic()
    {
        //Unload the music in the main menu
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            GameManager.instance.gameMusic.gameObject.SetActive(false);
        }
        else
        {
            GameManager.instance.gameMusic.gameObject.SetActive(true);
        }
    }


    void TogglePlayerVisibility()
    {
        //Unload the player on the Lose screen, win screen, and level complete screen
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            GameManager.instance.player.SetActive(false);
        }
        else
        {
            GameManager.instance.player.SetActive(true);
        }
    }

    //Removes the previous currentCheckpoint from other levels
    void RemoveCheckpoints()
    {
        if (currentCheckPoint == null)
        {
            Destroy(currentCheckPoint);
        }
    }

    //Updates the list in GameManager to only show the active checkpoints in the loaded scene
    //Removes checkpoint gameobjects that get destroyed once a new scene is loaded
    void RemoveDestroyedCheckpoints()
    {
        checkPoint.ForEach(delegate (GameObject checkpoint)
        {
            if(checkpoint == null)
            {
                checkPoint.Remove(checkpoint);
            }
        });
    }

    //Updates the list in GameManager to only show the active deathbarriers in the loaded scene
    //Removes deathbarrier gameobjects that get destroyed once a new scene is loaded
    void RemoveDestroyedDeathBarriers()
    {
        deathBarriers.ForEach(delegate (GameObject deathbarrier)
        {
            if (deathbarrier == null)
            {
                deathBarriers.Remove(deathbarrier);
            }
        });
    }

    //Get the last level that the player was on
    void GetLatestLevel()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(2) || SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3)) 
        {
            //Do nothing
        }
        else
            latestLevel = SceneManager.GetActiveScene().buildIndex;
    }
}
