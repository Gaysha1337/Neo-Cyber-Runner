// SettingsController
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {
	
	public void ToMainMenu(){
		SceneManager.LoadScene("Menu");
	}

	public void ToSettings(){
		SceneManager.LoadScene("Settings");
	}
}
