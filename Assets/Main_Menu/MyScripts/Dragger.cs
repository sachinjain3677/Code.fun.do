using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour {

    public GameObject[] touchedObj = new GameObject[5];
    // Use this for initialization
    void Start () {
        touchedObj = GameObject.FindGameObjectsWithTag("GameController");
	}
	

    
    void Update()
    {
        Touch[] myTouches = Input.touches;
        //Get how much finger/tap in screen
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector3 mainPos = Camera.main.ScreenToWorldPoint(myTouches[i].position);
            Ray ray = Camera.main.ScreenPointToRay(myTouches[i].position);
            RaycastHit hit;
            mainPos.z = -4f;
            if (Physics.Raycast(ray, out hit, 20f))
            {
                //OnMouseDown()
                if (hit.collider != null && myTouches[i].phase == TouchPhase.Began)
                {
                    touchedObj[i] = hit.transform.gameObject;
                    print("Obj Touched!!");
                }
            }
            //OnMouseDrag
            int ID = myTouches[i].fingerId;
            if (touchedObj[ID] != null)
            {
                touchedObj[ID].transform.position = mainPos;
                print("Obj Dragged!!");
            }
            //OnMouseUp()
            if (myTouches[i].phase == TouchPhase.Ended && touchedObj[ID] != null)
            {
                touchedObj[ID].GetComponent<Rigidbody>().AddForce(Vector3.right * 50f);
                touchedObj[ID] = null;
                print("Obj Released!!");
            }
        }
    }
}
