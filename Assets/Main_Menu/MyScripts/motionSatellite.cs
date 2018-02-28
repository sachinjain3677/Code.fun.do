using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
//using Math; 

public class motionSatellite : MonoBehaviour {
	public GameObject earth; 
	public GameObject moon; 
	public float speed = 3f;
	public float w;
	private float T ;
	public float Period = 1;
	private float x,z; 
	public float a1 =60f; 
	public float am = 60f;
	public float bm = 60f;

	public float a1Times = 2;
	private float a2;
	public float b = 50f;
	public float b2 ;

	public float e1 = 0.1f;
	public float e2;
	private float PI = 3.14f; 
	private float t = 0; 
	public float focus = 0.6f; 
	private bool isCycle = true; 
	public static bool reset_motion = false;
	// Use this for initialization
	void Start () {
		a2 = a1 * a1Times;
		e2 = 1 - (1 - e1) * a1 / a2;
		b2 = 1.5f * b;

	}

	// Update is called once per frame
	void Update () {
		reset_motion = false;

        

		if (/*DefaultTrackableEventHandler.isEarthActive &&*/ isCycle){

		T =  Period;

		w = (2 * PI ) / T;
		t = t + Time.deltaTime; 

		//x = a * Mathf.Cos (w * t);
		//z = b * Mathf.Sin (w * t);
		//this.transform.position = new Vector3 (x + earth.transform.position.x, 0, z + earth.transform.position.z);
		//this.transform.position.z = z + earth.transform.position.z;
		//this.transform.position.y = 0;

		if (t < T) {

                gameObject.GetComponent<TrailRenderer>().enabled = true;
				

		/*	x = - a * Mathf.Cos (w * t) + a*focus;
			z = b * Mathf.Sin (w * t);
				this.transform.position = new Vector3 (x + earth.transform.position.x, earth.transform.position.y, z + earth.transform.position.z);*/

				x = a1 * e1 - a1 * Mathf.Cos (w * t);
				z = b * Mathf.Sin (w * t);
				this.transform.position = new Vector3 (x + earth.transform.position.x, earth.transform.position.y, z + earth.transform.position.z);

		} /*else if (t == 2*T || (t > 2*T && t < 3*T))
		{
			x = 2 * a * Mathf.Cos (w * t);
			z = b * Mathf.Sin (w * t);
			this.transform.position = new Vector3 (x + earth.transform.position.x, 0, z + earth.transform.position.z);


		} */else if (t > 2.5 * T) {
			x =   am * Mathf.Cos (2 * w * t - 3.14f) / 2 ;
			z = bm * Mathf.Sin ( 2* w * t -3.14f) / 2;
				this.transform.position = new Vector3 (x + moon.transform.position.x, moon.transform.position.y, z + moon.transform.position.z);


		} else {
			
		/*	x =  - 2 * a * Mathf.Cos (  w * t) + 10*a*focus;
			z =  b * Mathf.Sin (w * t);
				this.transform.position = new Vector3 (x + earth.transform.position.x, earth.transform.position.y , z + earth.transform.position.z);*/

				x = a2 * e2 - a2 * Mathf.Cos (w * t);
				z = b2 * Mathf.Sin (w * t);
				this.transform.position = new Vector3 (x + earth.transform.position.x, earth.transform.position.y, z + earth.transform.position.z);


		}
			if (t > 5 * T) {
                t = 0;
				reset_motion = true;
               
                gameObject.GetComponent<TrailRenderer>().Clear();
                gameObject.GetComponent<TrailRenderer>().enabled = false;
                
                
			}

	}
	}
}
