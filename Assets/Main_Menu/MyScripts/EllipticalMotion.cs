using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.Events;

public class EllipticalMotion : MonoBehaviour {

	public float z;
	public float x;
	public float y = 0;


	public Slider slider;


	public float speed;
	public float CentreShift = 0;
	public float RotationSpeed;

	float alpha = 0;
	float X;
	float Z;
	float Y;

	private float newRotationSpeed;
	private float newspeed;


	//private DefaultTrackableEventHandler sp = new DefaultTrackableEventHandler();



	Vector3 changeposition = new Vector3(0,0,0);
	private int i;

	// Use this for initialization
	void Start () {

	}




	public void OnValueChanged(float value)
	{
		newRotationSpeed = value * RotationSpeed;

		newspeed = value * speed;

		Debug.Log(RotationSpeed);
	}
	// Update is called once per frame
	void Update () {

		newRotationSpeed = slider.value * RotationSpeed;

		newspeed = slider.value * speed;

		transform.Rotate(Vector3.up, newRotationSpeed);

		GameObject Sun = GameObject.Find("Sun"); // to rotate around Sun's position instead of centre as sun moves by image target

		//float[] ds = sp.GetC;



		if (DefaultTrackableEventHandler.suns == 1 && ShowPlanets.go == true)
		{

			alpha = alpha + newspeed;

			//   this.GameObject.Transform.position.z = ;
			//  this.GameObject.Transform.position.x = ;

			X = x * Mathf.Sin(alpha * Mathf.PI / 180) + Sun.transform.position.x + CentreShift;

			Z = z * Mathf.Cos(alpha * Mathf.PI / 180) + Sun.transform.position.z;

			if (LoadOnClick.plane == true) {
				//GetComponentInChildren<TrailRenderer> ().Clear ();

				//GetComponentInChildren<TrailRenderer> ().enabled = false;
				//GetComponent<TrailRenderer>().widthMultiplier = 0;
				Y = 1.5f;
				//GetComponent<LineRenderer> ().enabled = false;

                //if(gameObject.GetComponent<TrailRenderer>() != null)
                //{
                  //  gameObject.GetComponent<TrailRenderer>().enabled = true;
                //}
				//
				//GetComponent<TrailRenderer>().widthMultiplier = 0.01f;


			} else {

                //GetComponent<TrailRenderer> ().Clear ();
                //if (gameObject.GetComponent<TrailRenderer>() != null)
                //{
                  //  gameObject.GetComponent<TrailRenderer>().enabled = false;
                //}
                //GetComponent<TrailRenderer>().widthMultiplier = 0;
                Y = y * Mathf.Sin(alpha * Mathf.PI / 180) + Sun.transform.position.y;
				//GetComponent<TrailRenderer>().widthMultiplier = 0.01f;
				//GetComponent<LineRenderer> ().enabled = true;

				//GetComponent<TrailRenderer> ().Clear();
				//GetComponentInChildren<TrailRenderer> ().enabled = true;
			}


			changeposition = new Vector3(X, Y, Z);




			transform.position = changeposition;
		}

		// alpha += 10;
		// X = x + (a * Mathf.Cos(alpha * .005));
		// Y = y + (b * Mathf.Sin(alpha * .005));
		// this.gameObject.transform.position = new Vector3(X, 0, Y);

	}
}
