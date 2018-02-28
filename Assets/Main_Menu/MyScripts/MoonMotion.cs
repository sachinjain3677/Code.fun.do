using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ToDo Try to use variables of Cameraposition class to set or reset the rotation of moon and earth in these scripts

public class MoonMotion : MonoBehaviour {

    /* private CameraPosition obj;
     private int s = 2;
     private int e = 2; */

    public Slider slider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (slider.IsActive())
        {
            transform.localPosition = new Vector3(3* Mathf.Sin(slider.value), 0.9f, 5+3 * Mathf.Cos(slider.value));

        }
        if(GameController.lunar == 1)
        {
            transform.localPosition = new Vector3(3f * Mathf.Sin(slider.value-3.14f), 0.9f,  3+3f * Mathf.Cos(slider.value-3.14f));
        }

        /* GameObject Earth = GameObject.Find("Earth");

         Vector3 EarthPosition = Earth.transform.position;

        /* obj = GetComponent<CameraPosition>();
         s = obj.sun;
         e = obj.earth;


         // to show the effect of Sun on Moon

         if (s==1)
         {
             transform.RotateAround(Vector3.zero, Vector3.up, 30 * Time.deltaTime);
         }

         if (e == 1)
         {
             transform.RotateAround(EarthPosition, Vector3.up, 1 * Time.deltaTime);
         }

         // to rotate around its own axis
         // Set speed to get the desired visualilzation (not Time.deltaTime)
         transform.Rotate(Vector3.up * 1);

         */

    }
}

// Exact eclipsing and shapes of moon can be viewed if sizes of the earth, moon and sun and the distances between them and also their speeds are in the same proportion to the actual values.
// But in that case we require the camera as fine as the human eye. 
// Hence perform R&D to get the desired values to show the phenomena realisitic.
