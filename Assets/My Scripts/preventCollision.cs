using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preventCollision : MonoBehaviour {

//	public GameObject player;

	// Use this for initialization
	void Update () {
		Physics.IgnoreLayerCollision (8, 10);
	}
	
	// Update is called once per frame
//	void Raycasting () {
//	}
}
