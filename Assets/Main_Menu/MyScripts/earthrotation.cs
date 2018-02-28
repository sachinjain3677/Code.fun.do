using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthrotation : MonoBehaviour {

	private float w;
	private float T = 360;
	private float PI = 3.14f;
	//public GameObject Sun;
	private float x;
	private float y;
	private Vector3 distance;
	private float R;
	private float t = 0;	
	//public GameObject light1;



	// Use this for initialization
	void Start () {
		w = 2 * PI / T;
		//distance = (Sun.transform.position - this.transform.position);
		R = distance.magnitude;
	}

	// Update is called once per frame
	void Update () {
		t = t + Time.deltaTime;

		x = R * Mathf.Sin (w * t *60f);
		y = - R * Mathf.Cos (w * t*60f);
		//this.transform.position = new Vector3 (x,y,0);
		this.transform.Rotate (0,-Time.deltaTime*60f,0);


	}
}
