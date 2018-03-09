using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTriggerScript : MonoBehaviour {
	public AudioSource music;
	public GameObject dead;

	immunity im;
	randomLevelMaker_cfd rlm;

	void Start ()
	{
		rlm = GameObject.Find ("GameController").GetComponent<randomLevelMaker_cfd> ();
	}

	void OnTriggerEnter(Collider collider){
		if(collider.tag=="Player"){
			Destroy (collider.gameObject);
			music.Play ();
		}

		if(collider.tag=="Enemy_moving"){
			im = collider.gameObject.GetComponent<immunity> ();

			if (!im.immune) {
				Vector3 rot = new Vector3 (collider.transform.eulerAngles.x, collider.transform.eulerAngles.y, collider.transform.eulerAngles.z);
				dead.transform.eulerAngles=rot;
				Vector3 tra = new Vector3 (collider.transform.position.x,collider.transform.position.y,collider.transform.position.z);
				dead.transform.position=tra;
				Destroy(collider.gameObject);
				Instantiate (dead);
				rlm.enemyCount--;
				//rlm.set_count_canvas ();
			}


		}
	}

	//void OnTriggerStay(Collider collider){
	//}

	
}
