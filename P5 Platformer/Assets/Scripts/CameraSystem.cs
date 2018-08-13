using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        float x = Mathf.Clamp(player.transform.position.x,GameManager.instance.cameraXMin, GameManager.instance.cameraXMax);
        float y = Mathf.Clamp(player.transform.position.y, GameManager.instance.cameraYMin, GameManager.instance.cameraYMax);
        gameObject.transform.position = new Vector3(x + GameManager.instance.xOffset, y + GameManager.instance.yOffset, gameObject.transform.position.z);

    }
}