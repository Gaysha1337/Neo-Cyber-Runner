// ToggleHardMode
using UnityEngine;
using UnityEngine.UI;

public class ToggleHardMode : MonoBehaviour{
	public Text toggletext;
	private bool hard_off;


	void Awake(){
		toggletext.text = PlayerPrefs.GetString("HardModeBtnText", "Turn Hard Mode On");
	}

	public void ToggleHard(){
		if (!hard_off){
			hard_off = true;
			PlayerPrefs.SetString("Difficulty", "hard_on");
			UpdateText("Turn Hard Mode Off");
		}
		else if (hard_off){
			hard_off = false;
			PlayerPrefs.SetString("Difficulty", "hard_off");
			UpdateText("Turn Hard Mode On");
		}
		PlayerPrefs.Save();
	}

	private void UpdateText(string value){
		toggletext.text = value;
		PlayerPrefs.SetString("HardModeBtnText", toggletext.text);
		toggletext.text = PlayerPrefs.GetString("HardModeBtnText");
	}
}
