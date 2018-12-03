using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

	private CharacterController controller;
	private Vector3 playerMoveVector;
	
	private float speed = 10.0f;
	private float verticalVelocity = 0.0f; // used when calculating if the player has fallen off the tiles
	private float gravity = 12.0f;

	private float animationDuration = 3.0f; // used to prevent the player from moving during the camera animation

	private bool isDead = false; // We aint dead when the game starts
	private float startTime; // used to prevent the player from moving when scene is reloaded

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		controller = GetComponent<CharacterController>();
		
		
	}
	
	// Update is called once per frame
	void Update () {

		if(isDead == true){ // if dead stop game, and exit Update
			gameObject.SetActive(false); // turns the player off
			return;
		}

		// if no music playing and the player is alive, player is alive play music
		if (!AudioManager.instance.background_music.isPlaying && !isDead){
			AudioManager.instance.background_music.Play();
		}

		//if the time since the loading of the reloaded scene is smaller than the animation duration, move player forward, but restrict strafing
		if(Time.timeSinceLevelLoad < animationDuration){ // if the current time is below 3 seconds, move forward (player cant control)
			controller.Move(Vector3.forward * speed * Time.deltaTime);
			return; // prevents the rest of the code from being run until the condition is true
		}
		playerMoveVector = Vector3.zero; // resets the player's moveVector every frame for recalculation

		//Check if the player is on the ground
		checkIfPlayerGrounded();


			
		
		//X - Left and Right
		playerMoveVector.x = Input.GetAxisRaw("Horizontal") * speed;

		// is the player holding down any where on the screen?
		if(Input.GetMouseButton(0)){

			// if mouse position x is bigger than half of screen - we are on the rightside
			if(Input.mousePosition.x > Screen.width / 2){
				playerMoveVector.x = speed; // move right according to the speed of the player
			}
			else{
				playerMoveVector.x = -speed; // move left according to the speed of the player
			}
		}
		//Y - Up and Down (Prevents player from going up, but used if they fall off the tile)
		playerMoveVector.y = verticalVelocity;
		//Z - Forwards and Backwards
		playerMoveVector.z = speed; // no need for a bakcwards value, so we just use the player's speed to advance forward
		
		controller.Move(playerMoveVector * Time.deltaTime );
		
		
	}

    void checkIfPlayerGrounded(){
		if(controller.isGrounded){ // controller is on the ground
			verticalVelocity = -0.5f;
		}
		else{ // not the floor, i.e: falling 
			verticalVelocity = verticalVelocity - gravity * Time.deltaTime;
		}
    }

	private void OnControllerColliderHit(ControllerColliderHit hit){
		// if collision point is further than player's hitbox, then we hit something in front


		if(PlayerPrefs.GetInt("Difficulty") == 1){
			if(hit.gameObject.tag == "Border"){
				Death();
			}
		}
		
		if(hit.gameObject.tag == "Ennemy"){
			Death();
		}

	}

	private void Death(){
		//print("dead");
		isDead = true;
		GetComponent<Score>().OnDeath(); // used to stop the score when the player dies
		if(AudioManager.instance.background_music.isPlaying){
			AudioManager.instance.background_music.Stop();
		}

	}
	public void SetSpeed(float speedModifier){
		// this method is used to set the speed of the player when the difficulty of the game increases; the difficulty level is the speed parameter
		// that difficulty is determined by the current difficulty level which is in the score script
		speed = speed + speedModifier;
	}
}
