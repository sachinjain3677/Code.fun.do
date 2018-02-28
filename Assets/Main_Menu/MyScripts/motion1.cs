using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
//using Math; 

public class motion1 : MonoBehaviour {
	public GameObject earth; 
	public float speed = 3f;
	public float w;
	private float T ;
	public float Period = 10;
	private float x,z; 
	public float a =200f; 
	public float b = 180f; 
	private float PI = 3.14f; 
	private float t = 0; 


	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

		if(/*DefaultTrackableEventHandler.isEarthActive*/true){

		T =  Period;

		w = (2 * PI ) / T;
		t = t + Time.deltaTime; 

		x = a * Mathf.Cos (w * t - 0.3f);
		z = b * Mathf.Sin (w * t -0.3f	);
		this.transform.position = new Vector3 (x + earth.transform.position.x, earth.transform.position.y, z + earth.transform.position.z);
		//this.transform.position.z = z + earth.transform.position.z;
		//this.transform.position.y = 0;
		
	}
		if (motionSatellite.reset_motion) {
			t = 0;
		}

	}
}
