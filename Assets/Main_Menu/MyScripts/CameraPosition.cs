using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CameraPosition : MonoBehaviour {

    //private int sun = 0;
    //private int earth = 0;
    //private int moon = 0;

    public GameObject Sun, Earth, Moon;

    private float R = 1.5f;
   // public GameObject Camera;

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public float alpha = 1;

    private float t = 0;

	// Use this for initialization
	void Start () {
        //Sun = GameObject.Find("Sun");
        //Earth = GameObject.Find("Earth");
        //Earth = GameObject.FindGameObjectWithTag("temp");
        //Moon = GameObject.Find("Moon");
    }
	
	// Update is called once per frame
	void Update () {

        slider3.gameObject.SetActive(false);
        slider2.gameObject.SetActive(false);
        slider1.gameObject.SetActive(false);

        //GameObject Sun = GameObject.Find("Sun");
        //GameObject Earth = GameObject.Find("Earth");
        //GameObject Earth = GameObject.FindGameObjectWithTag("temp");
        // Why this is working and Find only is not working but not the problem with moon 

        //GameObject Moon = GameObject.Find("Moon");
        //GameObject Earth1 = GameObject.Find("Earth1");

        //Vector3 EarthPosition = new Vector3();


        //Vector3 EarthPosition = Earth.transform.position;

        //if(gameObject.tag == "1")
        //{
        //   transform.position = Earth1Position;
        //}


        Vector3 EarthPosition = new Vector3(Earth.transform.localPosition.x, Earth.transform.localPosition.y, Earth.transform.localPosition.z);


            //if(GameController.earth == 0)
            //{
        Earth.transform.Rotate(Vector3.up, alpha * Time.deltaTime * 6.28f * slider1.value);
            //}

       // Earth.transform.RotateAround(Sun.transform.position, Vector3.up, alpha * 6.28f * Time.deltaTime * slider3.value / 365);

        Earth.transform.position = Sun.transform.position + new Vector3(4 * Mathf.Sin(alpha * 6.28f * t * slider3.value / 365), 0, 4 * Mathf.Cos(alpha * 6.28f * t * slider3.value / 365));
      
        // to rotate around its own axis
        // check the original relative direction of rotation of moon and earth
        //transform.Rotate(Vector3.up * 1);

        StateManager sm = TrackerManager.Instance.GetStateManager();

        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        foreach (TrackableBehaviour tb in activeTrackables)
        {

            if (tb.TrackableName == "r" || tb.TrackableName == "e")
            {
                slider3.gameObject.SetActive(false);
                slider2.gameObject.SetActive(false);
                slider1.gameObject.SetActive(true);
            }
            else if(tb.TrackableName == "w")
            {
                slider1.value = 1;
                slider2.value = 1;
                slider3.value = 1;
                slider3.gameObject.SetActive(false);
                slider2.gameObject.SetActive(false);
                slider1.gameObject.SetActive(false);
                //Moon.transform.RotateAround(EarthPosition, Vector3.up, alpha * 6.28f * Time.deltaTime * slider2.value / 28);
                //t = t + Time.deltaTime;
                Moon.transform.position = Earth.transform.position + new Vector3(R * Mathf.Cos(t * alpha * 6.28f * slider2.value / 27), 0, R * Mathf.Sin(t * alpha * 6.28f * slider2.value / 27));
               // t = t + Time.deltaTime;
            }
            else if(tb.TrackableName == "a" || tb.TrackableName == "t")
            {
                slider3.gameObject.SetActive(true);
                slider2.gameObject.SetActive(true);
                slider1.gameObject.SetActive(true);
                Moon.transform.localPosition = Earth.transform.localPosition + new Vector3(R * Mathf.Sin(t * alpha * 6.28f * slider2.value / 27), 0, R * Mathf.Cos(t * alpha * 6.28f * slider2.value / 27));
              //  t = t + Time.deltaTime;
                //could be achieved by adding translation to moon according to earth + above Rotate Around
            }
            else
            {
                slider3.gameObject.SetActive(false);
                slider2.gameObject.SetActive(false);
                slider1.gameObject.SetActive(false);
            }

        }

    

        //Camera.SetActive(true);

        
        Moon.transform.Rotate(Vector3.up * alpha*6.28f*slider1.value*Time.deltaTime/27);
        Sun.transform.Rotate(Vector3.up *6.28f* 2*slider1.value*Time.deltaTime);
        /*if (sun == 1)
        {
            Earth.transform.RotateAround(Vector3.zero, Vector3.up, 30 * Time.deltaTime);   
            Moon.transform.RotateAround(Vector3.zero, Vector3.up, 30 * Time.deltaTime);
        }
        if(earth == 1)
        {
            Moon.transform.RotateAround(EarthPosition, Vector3.up, 30 * Time.deltaTime);
        }

        if (sun == 0)
        {
            Sun.GetComponent<MeshRenderer>().enabled = false;
        }
        if (earth == 0)
        {
            Earth.GetComponent<MeshRenderer>().enabled = false;
        }
        if (moon == 0)
        {
            Moon.GetComponent<MeshRenderer>().enabled = false;
        }
        */


        //Moon.transform.RotateAround(Vector3.zero, Vector3.up, 80 * Time.deltaTime*slider2.value);



        t = t + Time.deltaTime;

        //sun = 0;
        //earth = 0;
        //moon = 0;
        
    }

}


