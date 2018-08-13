using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Transform playerTrans;
    Rigidbody2D rb;
    Vector3 raycastPosition;
    int jumpsLeft;
    //public LayerMask mask = 1;


    // Use this for initialization
    void Start ()
    {
        jumpsLeft = GameManager.instance.playerJumpAmount;
        GameManager.instance.player = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
        playerTrans = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Controls();
    }

    void Controls()
    {
        //Detect if the player is on the ground
        RaycastHit2D hit;
        raycastPosition = playerTrans.position + new Vector3(0, GameManager.instance.raycastOffset, 0);
        hit = Physics2D.Raycast(raycastPosition, Vector2.down, .1f, 1 << 0);
        Debug.DrawRay(raycastPosition, Vector2.down * .1f, Color.red);
        GameManager.instance.playerJumpsRemaining = jumpsLeft;

        if (hit.collider != null)
        {
            GameManager.instance.isGrounded = true;

            //If player is on the ground refill their jump amount if it isn't already maxed out
            if (jumpsLeft != GameManager.instance.playerJumpAmount)
            { jumpsLeft = GameManager.instance.playerJumpAmount; }
            GetComponent<Animator>().SetBool("isJumping", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }

        //Play the walk animation when the player presses th move keys
        if ((Input.GetKey(KeyCode.A) && hit.collider != null) || (Input.GetKey(KeyCode.D) && hit.collider != null))
        {
            GetComponent<Animator>().SetBool("isWalking", true);
        }
        else GetComponent<Animator>().SetBool("isWalking", false);

        //Move the player sprite to the right
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            playerTrans.Translate(Vector3.right * GameManager.instance.playerSpeed * Time.deltaTime);
        }

        //Move the player sprite to the left
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            playerTrans.Translate(Vector3.left * GameManager.instance.playerSpeed * Time.deltaTime);
        }
        //Play the jump animation when the player jumps
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetBool("isWalking", false);
            GetComponent<Animator>().SetBool("isJumping", true);
            Jump();
        }

    }

    void Jump()
    {
        //Allow for multiple jumps
        if (jumpsLeft != 0)
        {

            rb.velocity = Vector3.up * GameManager.instance.playerJumpVelocity;
            jumpsLeft--;
            GameManager.instance.isGrounded = false;
            GameManager.instance.playerJumpSound.Play();

        }
    }
}
	
