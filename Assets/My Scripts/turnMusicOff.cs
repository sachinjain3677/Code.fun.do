using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnMusicOff : MonoBehaviour {

	AudioSource[] sounds;
	GreatArcStudios.PauseManager pm;
	Timer timer;
	score_counter sc;

	public GameObject player;
	public GameObject scoreCanvas_running;


	// Use this for initialization
	void Start () {
		sounds = GameObject.Find ("OnGameStart").GetComponents<AudioSource> ();	

		foreach (AudioSource sound in sounds)
			sound.enabled = false;

		pm = GameObject.Find ("Pause Menu Manager").GetComponent<GreatArcStudios.PauseManager> ();
		pm.ourFunction_pause ();
		timer = GameObject.Find ("GameController").GetComponent<Timer> ();
		sc = GameObject.Find ("GameController").GetComponent<score_counter> ();
	
		if (player != null) {
			sc.net_score += (int)timer.value_on_timer;
		}

		scoreCanvas_running.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
