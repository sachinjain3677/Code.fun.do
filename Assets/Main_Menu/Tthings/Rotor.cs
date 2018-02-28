using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class Rotor : MonoBehaviour {

	//public Button CassiniPlay;


	private void Update()
	{
		transform.Rotate(new Vector3(0, 15, 0) * Time.deltaTime);
		//Button A = CassiniPlay.GetComponent<Button> ();
		//A.onClick.AddListener (CassiniPlay);
	}
	void Taskonclick()
	{
		Debug.Log ("you have clicked the button");
	}
}
