using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource background_music;

	public static AudioManager instance = null; // instance of the type audioManager; only one instance. 

	void Awake(){

		// if audioManager instance is null, set it to this 
		if(instance == null){
			instance = this;
		}
		// if audioManager instance does not equal this, destroy the entire gameobject
		else if (instance != this){
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this); // ensures that the audio is running

		
	}	

	// Use this for initialization
	void Start () {
		background_music.volume = PlayerPrefs.GetInt("AudioVolume");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
