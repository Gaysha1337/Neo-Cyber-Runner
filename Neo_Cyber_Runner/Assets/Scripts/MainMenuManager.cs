using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

	public Text highscoreText;

	// Use this for initialization
	void Start () {
		AudioManager.instance.background_music.Play(); // starts the background music
		highscoreText.text = "Highscore: " + (int)PlayerPrefs.GetFloat("Highscore");
		
	}

	void Update(){
		
	}

	public void PlayGame(){
		SceneManager.LoadScene("Game");
	}

	public void ToSettings(){
		SceneManager.LoadScene("Settings");
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void ToMainMenu(){
		SceneManager.LoadScene("MainMenu");
	}

	
}
