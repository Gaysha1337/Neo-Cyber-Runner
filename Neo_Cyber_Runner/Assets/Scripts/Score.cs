using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	private float score = 0.0f; // score at the start of each new game
	public Text scoreText;
	
	private int difficultyLevel = 1; // Determins the player's speed and the amount of points they earn
	private int maxDifficultyLevel = 10; //The max difficulty the player can each when the game is running, in terms of score and speed
	private int scoreToNextLevel = 10; // the score needed to level up

	private bool isDead = true;

	public DeathMenu deathMenu; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// handles leveling up; if current score is equal or bigger to the score needed to level up; call LevelUp()
		// first level 0, 2nd level 10, 3rd level 20, 4th level 40 ...
		if(score >= scoreToNextLevel){
			LevelUp();
		}
		score = score + Time.deltaTime * difficultyLevel ;// Each second the player earn's a point, times their difficulty level

		//type casts the score from a float to an int
		scoreText.text = ((int) score).ToString();
		
	}

	void LevelUp(){
		// handles with increasing the score needed to level up by multiplying it with a value, to increase the score needed to level up
		// makes sure that the score to level up is not the same, by altering it's value by times 2
		if(difficultyLevel == maxDifficultyLevel){ // ensures that the game is playable by not being to fast by exceeding the max difficully level
			return;
		}
		scoreToNextLevel *= 2;
		difficultyLevel++; // increments difficulty level
		GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
	}

	public void OnDeath(){
		// this method will be called from the playerMotor script;
		// when player collides with onj, this method will be called in PlayerMotor and will stop the Score from increasing
		isDead = true;

		if(PlayerPrefs.GetFloat("Highscore") < score){ // if highscore is smaller than score assign new highscore.
			PlayerPrefs.SetFloat("Highscore",score); // save the score to the user's device's storage
		}
		
		deathMenu.ToggleEndMenu(score); // turns on the death menu, and sends the player's score to be displayed on the death menu
	}
}
