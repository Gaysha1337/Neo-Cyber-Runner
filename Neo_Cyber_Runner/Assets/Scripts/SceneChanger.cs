using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

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
