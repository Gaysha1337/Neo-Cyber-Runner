// ToggleMusic
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour{
	public Text ButtonText;
	public GameObject AudioManager;
	private bool isMuted;
	private bool soundToggle = true;

	void Awake(){
		ButtonText.text = PlayerPrefs.GetString("btnText", "Turn Music Off");
		AudioListener.volume = PlayerPrefs.GetFloat("Volume", 1f);
	}

	public void MusicToggle(){
		soundToggle = !soundToggle;
		if (soundToggle){
			AudioListener.volume = 1f;
			UpdateButtonText("Off");
			PlayerPrefs.SetFloat("Volume", AudioListener.volume);
		}
		else{
			AudioListener.volume = 0f;
			UpdateButtonText("On");
			PlayerPrefs.SetFloat("Volume", AudioListener.volume);
		}
		PlayerPrefs.Save();
	}

	private void UpdateButtonText(string value){
		ButtonText.text = "Turn Music " + value;
		PlayerPrefs.SetString("btnText", ButtonText.text);
		ButtonText.text = PlayerPrefs.GetString("btnText");
		MonoBehaviour.print(AudioListener.volume + ButtonText.text);
	}


}
