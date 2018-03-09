using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countingNumbersController : MonoBehaviour {

	float time_so_far;
	float start_time;

	public Text label;
	public GameObject gameController;
	public GameObject startSounds;
	public GameObject countCanvas;

	// Use this for initialization
	void Start () {
		time_so_far = 0.0f;
		start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Math.Floor(Time.time - start_time) - time_so_far == 1.0f) {
			//Debug.Log (Time.time);

			if (2.0f - time_so_far == -1.0f) {
				gameController.SetActive (true);
				startSounds.SetActive (true);
				countCanvas.SetActive (true);
				gameObject.SetActive (false);
			} else {
				label.text = "" + (int)(2.0f - time_so_far);
				time_so_far = time_so_far + 1.0f;
			}
		}
	}
}
