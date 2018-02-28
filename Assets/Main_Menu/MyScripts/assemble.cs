using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assemble : MonoBehaviour {

	private bool isArm, isBody, isPanel, isSuspension, isMast;
	Animator Anim;
	//public GameObject Arm;
	//public GameObject Body;
	//public GameObject Panel;
	//public GameObject Suspension;
	//public GameObject Mast;
	public GameObject Main;
	private GameObject temp;
	private GameObject[] components = new GameObject[10];
	public static bool isassembled;


	

	// Use this for initialization
	void Start () {
		Anim = GetComponent<Animator> ();
		Anim.SetBool ("isAssembled",true);
		//isAssembled = false; 
		//temp = MER;

		for( int i=0;  i <  Main.transform.childCount; i++ )
		{
			components [i] = Main.transform.GetChild (i).gameObject;
		//	Main.transform.GetChild (i).gameObject.SetActive (false); 

		}
	//	Main.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown ("a")) 
		{
			for (int i = 0; i < components.Length; i++)
			//	Arm.SetActive (true);
				if (components [i].CompareTag ("arm")) {
					components [i].SetActive (true);
					isArm = true;


				}
		}
			


		/* if(Input.GetKeyDown("b"))

			{
			
			//	if (child.gameObject.CompareTag ("body")) 
					{
				Main.SetActive (true);
			//			child.gameObject.SetActive (true);
						isBody = true;
					}
				}
				*/
			
			 if(Input.GetKeyDown("p"))
			{
			for (int i = 0; i < components.Length; i++)
				//	Arm.SetActive (true);
				if (components [i].CompareTag ("panel")) {
					components [i].SetActive (true);
					isPanel = true;


				}
			}
			if(Input.GetKeyDown("s"))
			{
			for (int i = 0; i < components.Length; i++)
				//	Arm.SetActive (true);
				if (components [i].CompareTag ("suspension")) {
					components [i].SetActive (true);
					isSuspension = true;


				}
			}
			if(Input.GetKeyDown("m"))
			{
			for (int i = 0; i < components.Length; i++)
				//	Arm.SetActive (true);
				if (components [i].CompareTag ("mast")) {
					components [i].SetActive (true);
					isMast = true;


				}
			}
			if (isArm  && isPanel && isSuspension && isMast) 
			{
				Anim.SetBool ("isAssembled",true);
				
			}
		}
	}



