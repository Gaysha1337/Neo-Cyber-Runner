using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public Text endScoreText;
	public Image backgroundImage; // black screen that appears when the player dies
	private Color transparentColor = new Color(0,0,0,0);

	private bool isBgImgShown = false; // background image is not shown until death

	private float transition = 0.0f;

	// Use this for initialization
	void Start () {

		// turns the death menu off when the game is starting
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!isBgImgShown){ // if background image is not shown(enabled); return
			return;
		}
		transition = transition + Time.deltaTime;
		//lerps between a transparent color and black by transition
		backgroundImage.color = Color.Lerp(transparentColor,Color.black,transition);
		
	}

	public void ToggleEndMenu(float score){
		// Player has died
		gameObject.SetActive(true);
		endScoreText.text = ((int)score).ToString();
		isBgImgShown = true;
	}

	public void RestartGame(){
		// loads the active scene (the game scene), by getting the name of the current active scene (game scene)
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ToMainMenu(){
		SceneManager.LoadScene("MainMenu");
	}


}
