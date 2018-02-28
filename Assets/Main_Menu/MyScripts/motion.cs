using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class motion : MonoBehaviour {

    //  private CameraPosition obj;
    //private int s = 2;

    private GameObject[] players;
    public Slider slider;

	// Use this for initialization
	void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        //s = CameraPosition.sun;

        /*  obj = Get
         *  Component<CameraPosition>();
          s = obj.sun;


          if (s == 1)
          {

          }


          // to rotate around its own axis*/
        
        if(slider.IsActive())
        {
            transform.position = new Vector3(1000 * Mathf.Sin(slider.value), 0, 1000 * Mathf.Cos(slider.value));

        }
        else
        {
            transform.RotateAround(Vector3.zero, Vector3.up, 30 * Time.deltaTime);
        }

        transform.Rotate(Vector3.up * 1);

        foreach(GameObject pl in players)
        {
            pl.GetComponent<MeshRenderer>().enabled = true;
            pl.SetActive(true);
            pl.GetComponent<CapsuleCollider>().enabled = true;
        }
   

        Debug.DrawRay(Vector3.zero, new Vector3(3.5f*transform.position.x, 3.5f * transform.position.y, 3.5f * transform.position.z), Color.green);

        Ray ray = new Ray(Vector3.zero, new Vector3(3.5f * transform.position.x, 3.5f * transform.position.y, 3.5f * transform.position.z));
        
        RaycastHit hit;

        if (Physics.Raycast(Vector3.zero, transform.position, out hit, 100000000.0f))
        {
            Debug.Log("Found an object - distance: " + hit.distance);
            hit.collider.GetComponent<MeshRenderer>().enabled = false;
            hit.collider.gameObject.SetActive(false);
        }
            
    }
}
