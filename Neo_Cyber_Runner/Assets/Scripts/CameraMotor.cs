using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

	[SerializeField]
	private Transform playerTransform;
	private Vector3 cameraOffset;
	private Vector3 cameraMoveVector;

	private float transition = 0.0f; // relates to the start "animation" where the player cant move until it is done
	private float animationDuration = 3.0f;
	private Vector3 animationOffset= new Vector3(0,5,5);


	// Use this for initialization
	void Start () {
		// distance between the camera position and the player's position
		cameraOffset = transform.position - playerTransform.position;
	}
	
	void Update() {
		if(playerTransform.gameObject.activeSelf == false){
			return;
		}
	}

	// Update is called once per frame
	void LateUpdate () {
		cameraMoveVector = playerTransform.position + cameraOffset;
		// X
		cameraMoveVector.x = 0.0f; // ensures that the x axis is always in the center; camera wont strafe with player
		// Y
		cameraMoveVector.y = Mathf.Clamp(cameraMoveVector.y,3,5); // ensures that the y axis is between 3 and 5
		
		if(transition > 1.0f){ // the animation has ended
			// the camera will follow the player
			transform.position = cameraMoveVector;
		}
		else{ // the animation is occuring or about to

			// Finds a vector in between the camMoveVector + offset and camMoveVector, by the transiotion
			transform.position = Vector3.Lerp(cameraMoveVector + animationOffset, cameraMoveVector, transition);			
			// 1 sec / 3;
			// idk what this really does, but in short it changes the transition value until it reaches the animation duration, meaning the animation has ended.
			transition = transition + Time.deltaTime / animationDuration; 
			// Make the camera look at the player, with some added height for improved visibility
			transform.LookAt(playerTransform.position + Vector3.up);
		}
		
	}
}
