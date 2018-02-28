using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HoldButtonEventHandler : MonoBehaviour {
	public UnityEvent OnButtonHeld;
	public UnityEvent OnButtonRelease;

	private bool pressed = false;
	private bool haspressed = false; 
	//private Motion mymotion ; 



	// Use this for initialization
	void Start () {
		//mymotion = new Motion ();
	}
	public void SetPressed(bool value) 
	{
		pressed = value;
	}

	
	// Update is called once per frame
	void Update () {
		if (pressed) {
			OnButtonHeld.Invoke ();
	//		Debug.Log ("Has pressed UP");
			haspressed = true;

			//mymotion.MoveFwd ();
		} else
		{
			if (haspressed == true)
			OnButtonRelease.Invoke();
			haspressed = false;
			//mymotion.Idle ();
		}
		
	}
}
