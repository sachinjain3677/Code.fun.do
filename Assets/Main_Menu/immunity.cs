using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class immunity : MonoBehaviour {

	public bool immune;
	public float immunity_time;

	// Use this for initialization
	void Start () {
		immune = true;
	}

	IEnumerator makeVulnerable(){
		yield return new WaitForSeconds (immunity_time);
		immune = false;
	}

}
