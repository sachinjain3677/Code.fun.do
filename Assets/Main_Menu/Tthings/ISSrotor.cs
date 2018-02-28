using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISSrotor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		transform.Rotate(new Vector3(15, 0, 0) * Time.deltaTime);
	}
}
