using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class immunity : MonoBehaviour {

	public bool immune;
	public float immunity_time;

	// Use this for initialization
	void Start () {
		immune = true;
		StartCoroutine (makeVulnerable ());
	}

	IEnumerator makeVulnerable(){
		yield return new WaitForSeconds (immunity_time);
		Debug.Log ("Immunity removed");
		immune = false;
	}

}
