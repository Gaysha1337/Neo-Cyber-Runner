using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HardModeToggle : MonoBehaviour {

	public Text HardModeButtonText;


	// Enum for differentiating difficulties
	public enum DifficultyMode{Easy,Hard};

	// Use this for initialization
	void Start () {
		HardModeButtonText.text = PlayerPrefs.GetString("DifficultyStatus","Turn on Hard Mode");
		
	}

	//FXME: STUCK ON HARD MODE

	public void ToggleHardMode(){
		if(PlayerPrefs.GetInt("Difficulty",0) == 0){ // if on easy, switch to hard
			PlayerPrefs.SetInt("Difficulty",1); // hard is set
			SetText("Turn off Hard Mode");

		}
		else{
			PlayerPrefs.SetInt("Difficulty",0); // easy is set
			SetText("Turn on Hard Mode");
		}
		PlayerPrefs.Save();
	}
	
	private void SetText(string text){
		PlayerPrefs.SetString("DifficultyStatus",text);
		HardModeButtonText.text = PlayerPrefs.GetString("DifficultyStatus");
	}
}
