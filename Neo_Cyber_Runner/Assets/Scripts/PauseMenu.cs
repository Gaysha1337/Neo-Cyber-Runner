using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject Player;
	public GameObject PauseMenuPanel;
	public Button PauseButton;

	// Use this for initialization
	void Start () {
		PauseMenuPanel.SetActive(false);
		Time.timeScale = 1f; // do not remove
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Player.activeSelf == false){
			PauseButton.gameObject.SetActive(false);
			
		}
		if(Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.P)){
			TogglePause();
		}
		
	}

	public void TogglePause(){
		if(PauseMenuPanel.activeSelf){
			PauseMenuPanel.SetActive(false);
			Time.timeScale = 1f; // game is not paused
		}
		else{
			PauseMenuPanel.SetActive(true);
			Time.timeScale = 0f; // game is paused
		}
	}


	public void ResumeGame(){
		PauseMenuPanel.SetActive(false);
		Time.timeScale = 1f;
	}

	public void RestartGame(){
		SceneManager.LoadScene("Game");
		Time.timeScale = 1f;
		print(Time.timeScale);
	}

	public void ToMainMenu(){
		SceneManager.LoadScene("MainMenu");
	}
}
