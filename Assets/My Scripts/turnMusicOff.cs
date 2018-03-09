using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnMusicOff : MonoBehaviour {

	AudioSource[] sounds;

	// Use this for initialization
	void Start () {
		sounds = GameObject.Find ("OnGameStart").GetComponents<AudioSource> ();	

		foreach (AudioSource sound in sounds)
			sound.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
