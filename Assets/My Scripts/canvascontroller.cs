using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvascontroller : MonoBehaviour {

	public GameObject readyCanvas;
	public GameObject startCanvas;
    public GameObject panel;
    public GameObject username;
    public GameObject submit;

	public void switchCanvas () {
		startCanvas.SetActive(true);
		readyCanvas.SetActive(false);
	}

    public void switchwithin()
    {
        panel.SetActive(true);
        username.SetActive(false);
        submit.SetActive(false);
    }
}
