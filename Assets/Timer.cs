using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float max_time;
	public Text timer_text;
	public GameObject gameOverMenu;
	public float value_on_timer;

	float time_passed;
	float time_value_on_start;
	int min;
	int sec;

	// Use this for initialization
	void Start () {
		time_passed = 0.0f;
		time_value_on_start = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		time_passed = (float)Mathf.Floor (Time.time - time_value_on_start);
		value_on_timer = max_time - time_passed;
		min = (int)value_on_timer / 60;
		sec = (int)value_on_timer % 60;
		if (min < 10) {
			if (sec < 10) {
				timer_text.text = "" + min + ":0" + sec;
			} else {
				timer_text.text = "" + min + ":" + sec;
			}
		} else {
			if (sec < 10) {
				timer_text.text = "" + min + ":0" + sec;
			} else {
				timer_text.text = "" + min + ":" + sec;
			}
		}

		if (value_on_timer == -1.0f) {
			gameOverMenu.SetActive (true);
			timer_text.text = "0:00";
		}
	}
}
