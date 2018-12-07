using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour {
	public Text musicButtonText;
	// Use this for initialization

	
	void Awake () {
		musicButtonText.text = PlayerPrefs.GetString("AudioStatus","Turn Music Off");
		AudioManager.instance.background_music.volume = PlayerPrefs.GetInt("AudioVolume",1);
	}

	private void SetText(string text){
		//musicButtonText.text = text;
		PlayerPrefs.SetString("AudioStatus",text);
		musicButtonText.text = PlayerPrefs.GetString("AudioStatus");
	}

	public void ToggleAudio(){
		// handles setting the player prefs
		if(PlayerPrefs.GetInt("AudioVolume",1) == 1){
			PlayerPrefs.SetInt("AudioVolume",0);
			print("vol = 0");
			SetText("Turn Music On");
		}
		else{
			PlayerPrefs.SetInt("AudioVolume",1);
			SetText("Turn Music Off");
			print("vol = 1");
		}

		// Implement a method to set the audi state depending on the saved playerPref
		SetAudioState();
		//PlayerPrefs.Save();
	}

	private void SetAudioState(){
		// Modifies Audio Output depending on set PlayerPrefs
		if(PlayerPrefs.GetInt("AudioVolume",1) == 1){
			AudioManager.instance.background_music.volume = 1;
			AudioManager.instance.background_music.Play();
		}
		else{
			AudioManager.instance.background_music.volume = 0;
			AudioManager.instance.background_music.Stop();

		}
	}

}
