using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control_direction_predictor : MonoBehaviour {

	float x;
	float y;
	float z;
	float net_angle_height;
	float rotation_y;
	float net_angle;
	float alpha;
	int rows;
	int columns;
	float effective_alpha_value;
	Color color;

	PlayerController pc;
	ObjectMatrix om;

	public GameObject ar_camera;
	//public Material s1;
	//public Material s2;
	//public Material s3;
	//public Material s4;
	public float alpha_value;

	public GameObject g1;
	public GameObject g2;
	public GameObject g3;
	public GameObject g4;


	public GameObject g1_inv;
	public GameObject g2_inv;
	public GameObject g3_inv;
	public GameObject g4_inv;

	void Start(){
		om = GameObject.Find ("GameController").GetComponent<ObjectMatrix> ();
		rows = om.rows;
		columns = om.columns;
		effective_alpha_value = alpha_value / 255;
	}


	void Update(){
		pc = GameObject.Find ("PlayerGameObject").GetComponent<PlayerController> ();

		rotation_y = ar_camera.transform.eulerAngles.y;
		net_angle = (rotation_y + 180.0f) % 360;
		alpha = (float)(Math.Atan (om.columns / om.rows) * 180 / Math.PI);
		//Debug.Log (ar_camera.transform.eulerAngles.y);

		net_angle_height = (float)(Math.Atan (ar_camera.transform.position.y / (Mathf.Sqrt( (x - om.rows/2) * (x - om.rows/2) + (z - om.columns/2) * (z - om.columns/2) ) + 25.0f)) * 180 / Math.PI);
		Debug.Log (net_angle_height);
		if (net_angle_height < 30.0f && net_angle_height > 0.0f) {
			if (net_angle > 90.0f - alpha) {
				if (net_angle < 90.0f + alpha) {
					pc.ar_camera_side = 3;
					//color = s4.color;
					//color.a = effective_alpha_value;
					g4_inv.SetActive (true);
					g1_inv.SetActive (false);
					g2_inv.SetActive (false);
					g3_inv.SetActive (false);

					g4.SetActive (false);
					g1.SetActive (true);
					g2.SetActive (true);
					g3.SetActive (true);
					Debug.Log (pc.ar_camera_side);
				} else if (net_angle < 270.0f - alpha) {
					pc.ar_camera_side = 0;
					//color = s1.color;
					//color.a = 0;
					g1_inv.SetActive (true);
					g2_inv.SetActive (false);
					g3_inv.SetActive (false);
					g4_inv.SetActive (false);

					g1.SetActive (false);
					g2.SetActive (true);
					g3.SetActive (true);
					g4.SetActive (true);
					Debug.Log (pc.ar_camera_side);
				} else if (net_angle < 270.0f + alpha) {
					pc.ar_camera_side = 1;
					//color = s2.color;
					//color.a = effective_alpha_value;
					g2_inv.SetActive (true);
					g1_inv.SetActive (false);
					g3_inv.SetActive (false);
					g4_inv.SetActive (false);


					g2.SetActive (false);
					g1.SetActive (true);
					g3.SetActive (true);
					g4.SetActive (true);
					Debug.Log (pc.ar_camera_side);
				} else {
					pc.ar_camera_side = 2;
					//color = s3.color;
					//color.a = effective_alpha_value;
					g3_inv.SetActive (true);
					g1_inv.SetActive (false);
					g2_inv.SetActive (false);
					g4_inv.SetActive (false);


					g3.SetActive (false);
					g1.SetActive (true);
					g2.SetActive (true);
					g4.SetActive (true);
					Debug.Log (pc.ar_camera_side);
				}
			} else {
				pc.ar_camera_side = 2;
				//color = s3.color;
				//color.a = effective_alpha_value;
				g3_inv.SetActive (true);
				g1_inv.SetActive (false);
				g2_inv.SetActive (false);
				g4_inv.SetActive (false);


				g3.SetActive (false);
				g1.SetActive (true);
				g2.SetActive (true);
				g4.SetActive (true);
				Debug.Log (pc.ar_camera_side);
			}
		} else {
			g3_inv.SetActive (false);
			g1_inv.SetActive (false);
			g2_inv.SetActive (false);
			g4_inv.SetActive (false);
		
			g3.SetActive (true);
			g1.SetActive (true);
			g2.SetActive (true);
			g4.SetActive (true);
		}
	}


	// Update is called once per frame
	/*void Update () {
		pc = GameObject.Find ("PlayerGameObject").GetComponent<PlayerController> ();
		//uncomment if change controls according to ar camera position
		z = transform.position.z;
		x = transform.position.x;
		if (2 * z < x) {
			if (2 * (14 - z) > x) {
				pc.ar_camera_side = 0;
			} else if (2 * (14 - z) < x) {
				pc.ar_camera_side = 3;
			}
		} else if (2 * z > x) {
			if (2 * (14 - z) > x) {
				pc.ar_camera_side = 1;
			} else if (2 * (14 - z) < x) {
				pc.ar_camera_side = 2;
			}
		}	


		//uncomment if change controls according to rotation of ar camera
	//	rotation_y = transform.rotation.y;
	//	if (rotation_y < 0) {
	//		rotation_y = 360.0f - Mathf.Abs (rotation_y) % 360;
	//	}
	
	//	if (rotation_y > 360) {
	//		rotation_y = rotation_y % 360;
	//	}

	//	if (rotation_y > 120.0f) {
	//		if (rotation_y < 240.0f) {
	//			pc.ar_camera_side = 2;
	//		} else if (rotation_y < 300.0f) {
	//			pc.ar_camera_side = 3;
	//		} else {
	//			pc.ar_camera_side = 0;
	//		}
	//	} else { 
	//		if (rotation_y > 60.0f) {
	//			pc.ar_camera_side = 1;
	//		} else {
	//			pc.ar_camera_side = 0;
	//		}
	//	}
	}*/
}
