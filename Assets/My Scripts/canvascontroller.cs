using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvascontroller : MonoBehaviour {

	public GameObject readyCanvas;
	public GameObject startCanvas;

	public void switchCanvas () {
		startCanvas.SetActive(true);
		readyCanvas.SetActive(false);
	}
}
