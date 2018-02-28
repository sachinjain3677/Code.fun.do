using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class GameController : MonoBehaviour {

    private GameObject[] Cameras;

    public static int lunar = 0;

    public static int earth = 0;

    public Light[] point_lights;

    public Light MainLight;

    public Text[] text;

    public Text tt;

    private GameObject[] textobjects;

    public GameObject textpanel;
    //private GameObject[] textpanels;
    List<GameObject> textpanels = new List<GameObject>();
    //private Text[] lookattext;


    private GameObject[] dtexts;

	void Start () {

        //lookattext = GameObject.FindObjectsOfType<Text>();
        Cameras = GameObject.FindGameObjectsWithTag("Camera");


        /* for (int i = 0; i < textobjects.Length; i++)
         {
              textpanels.Add(Instantiate(textpanel/*.position, new Quaternion(textobjects[i].transform.rotation.x, textobjects[i].transform.rotation.y, textobjects[i].transform.rotation.z , textobjects[i].transform.rotation.w)) as GameObject);

            // textpanels[i].transform.SetPositionAndRotation(textobjects[i].transform.position, textobjects[i].transform.rotation);
             //textpanels[i].GetComponent<MeshRenderer>().enabled = false;
             textpanels[i].transform.SetParent(textobjects[i].transform);
             //textpanels[i].transform.localScale = new Vector3(textobjects[i].transform.localScale.x, textobjects[i].transform.localScale.y, textobjects[i].transform.localScale.z);

             //textpanels[i].transform.Rotate(new Vector3(0, 0, 90));
             //textpanels[i].SetActive(false);
             //textpanels[i].GetComponent<MeshRenderer>().enabled = false;
             //textpanels[i].transform.localScale = new Vector3(textobjects[i].transform.localScale.x*10, textobjects[i].transform.localScale.y*10, textobjects[i].transform.localScale.z * 100f);
         }*/

    }

	void Update () {

        dtexts = GameObject.FindGameObjectsWithTag("dtext");

        /*foreach (GameObject t in dtexts)
        {
            t.SetActive(false);
        }*/

        

        MainLight.gameObject.SetActive(true);

        tt.gameObject.SetActive(false);

        textobjects = GameObject.FindGameObjectsWithTag("text");

        foreach (GameObject t in textobjects)
        {
            t.transform.LookAt(new Vector3(Camera.main.transform.position.x * -1, t.transform.position.y, Camera.main.transform.position.z * -1), Vector3.up);
            if (t.transform.localRotation.y > 90)
            {
               // t.transform.localRotation = new Quaternion(t.transform.localRotation.x, 180f - t.transform.localRotation.y, t.transform.localRotation.z, t.transform.localRotation.z);
            }


            // Tried to chnage position of text dynamically but solved by just making it child object
            // t.transform.localPosition = new Vector3(0, t.GetComponentInParent<Transform>().localPosition.y + t.GetComponentInParent<Renderer>().bounds.size.y/2 + 0.3f, 0);
            // Debug.Log(t.transform.localPosition.y + " " + t.GetComponentInParent<Renderer>().bounds.size.y + " " + t.GetComponentInParent<Transform>().localPosition.y);
            // Track down why this local position keeps on increasing

            


    }
        foreach(GameObject t in dtexts)
        {
            t.transform.LookAt(new Vector3(Camera.main.transform.position.x * -1, t.transform.position.y, Camera.main.transform.position.z * -1), Vector3.up);
        }

        /* for (int i = 0; i < textobjects.Length; i++)
    {
        textpanels[i].transform.SetPositionAndRotation(textobjects[i].transform.position, new Quaternion(textobjects[i].transform.rotation.x , textobjects[i].transform.rotation.y, textobjects[i].transform.rotation.z, textobjects[i].transform.rotation.w));
        textpanels[i].transform.position = new Vector3(textobjects[i].transform.position.x, textobjects[i].transform.position.y, textobjects[i].transform.position.z + 0.12f);
        //textpanels[i].transform.Rotate(new Vector3(45, 0, 0));
        textpanels[i].GetComponent<MeshRenderer>().enabled = false;
        //textpanels[i].transform.SetParent(textobjects[i].transform);
        textpanels[i].transform.localScale = new Vector3(textobjects[i].transform.localScale.x, textobjects[i].transform.localScale.y, textobjects[i].transform.localScale.z);
        //Debug.Log(textpanels[i].transform);
    }*/




        lunar = 0;
        earth = 0;
        foreach (GameObject c in Cameras)
        {
            //c.GetComponent<Camera>().depth = 0;
            c.SetActive(false);
        }

        foreach(Light l in point_lights)
        {
            l.gameObject.SetActive(false);
        }
        foreach(Text t in text)
        {
            t.gameObject.SetActive(false);
        }
        StateManager sm = TrackerManager.Instance.GetStateManager();

        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();


        foreach (TrackableBehaviour tb in activeTrackables)
        {
            // Adding Background panel to text
          /*  for(int i =0;i<textobjects.Length;i++)
            {
                //Debug.Log(textobjects[i].GetComponentInParent<Transform>().gameObject.GetComponentInParent<Transform>().gameObject.name);
                Debug.Log(textobjects[i].transform.parent.gameObject.transform.parent.gameObject.name);
                if(/*textobjects[i].activeSelf == true//textobjects[i].transform.parent.gameObject.transform.parent.gameObject.name == tb.gameObject.name)
                {
                    //textpanels[i].SetActive(true);
                    textpanels[i].transform.localScale = new Vector3(70/* textobjects[i].GetComponent<TextMesh>().text.Length * textobjects[i].GetComponent<TextMesh>().fontSize, textobjects[i].transform.localScale.y*100 , textobjects[i].transform.localScale.z*0.2f);
                    //textpanels[i].transform.localScale = new Vector3(10, 15 , textobjects[i].transform.localScale.z * 5f);
                    //textpanels[i].transform.rotation = new Quaternion(textpanels[i].transform.rotation.x, textpanels[i].transform.rotation.y, textpanels[i].transform.rotation.z + 90, textpanels[i].transform.rotation.w);
                   // textpanels[i].transform.Rotate(new Vector3(90, 0, 0));
                    textpanels[i].GetComponent<MeshRenderer>().enabled = true;

                    Debug.Log(true);
                }
                else
                {
                    //textpanels[i].SetActive(false);
                    textpanels[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }*/

            foreach (GameObject c in Cameras)
            {

                if (tb.TrackableName == "t")
                {
                    if(c.name == "C1")
                    {
                        //c.GetComponent<Camera>().depth = 2;
                        c.SetActive(true);
                    }
                    if (c.name == "C2")
                    {
                        //c.GetComponent<Camera>().depth = 2;
                        c.SetActive(true);
                    }
                    if ( c.name == "C3")
                    {
                        //c.GetComponent<Camera>().depth = 2;
                        c.SetActive(true);
                    }
                }
                if (tb.TrackableName == "r")
                {
                    if (c.name == "C4")
                    {
                        //c.GetComponent<Camera>().depth = 2;
                        c.SetActive(true);
                    }
                    tt.gameObject.SetActive(true);
                }
                if (tb.TrackableName == "e")
                {
                    if (c.name == "C5")
                    {
                        //c.GetComponent<Camera>().depth = 2;
                        c.SetActive(true);
                    }
                    lunar = 1;
                    tt.gameObject.SetActive(true);
                }
                if (tb.TrackableName == "w")
                {
                    if (c.name == "C6")
                    {
                        //c.GetComponent<Camera>().depth = 2;
                        c.SetActive(true);
                    }
                    earth = 1;
                    tt.gameObject.SetActive(true);
                }
                if (tb.TrackableName == "q")
                {
                    if (c.name == "C7")
                    {
                        c.SetActive(true);
                    }
                    MainLight.gameObject.SetActive(false);
                    tt.gameObject.SetActive(true);
                }
            }
            if (tb.TrackableName == "t")
                {
                point_lights[0].gameObject.SetActive(true);
                foreach (Text t in text)
                {
                    t.gameObject.SetActive(true);
                }
            }
            if (tb.TrackableName == "r")
                {
                point_lights[1].gameObject.SetActive(true);
            }
            if (tb.TrackableName == "e")
                {
                point_lights[2].gameObject.SetActive(true);
            }
            if (tb.TrackableName == "w")
                {
                point_lights[3].gameObject.SetActive(true);
            }
            if (tb.TrackableName == "q")
                {
                point_lights[4].gameObject.SetActive(true);
            }
            if(tb.TrackableName == "a")
            {
                point_lights[5].gameObject.SetActive(true);
            }
            
        }

        
    }
}
