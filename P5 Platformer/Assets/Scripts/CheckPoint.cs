using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    Transform trans;
    bool hasBeenActivated;

    // Use this for initialization
    void Start ()
    {
        hasBeenActivated = false;
        trans = transform;

        //Add the gameObject this script is attached to the list of checkpoints in the GameManager
        GameManager.instance.checkPoint.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update ()
    {

        //Make currentCheckpoint the last checkpoint the player reached/passed
        //Prevent previous checkpoints from becoming the latest checkpoint
        if (hasBeenActivated == false)
        {
            if (GameManager.instance.player.transform.position.x >= trans.position.x)
            {
                GameManager.instance.currentCheckPoint = this.gameObject;
                hasBeenActivated = true;
            }
        }

    }
}
