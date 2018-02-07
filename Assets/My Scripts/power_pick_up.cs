using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_pick_up : MonoBehaviour {

	BombSpawnAndExplode_cfd bsae;
	PlayerController pc;
	public AudioSource music;

	public float speed_increase_factor;

	void Start(){
		bsae = GameObject.Find("GameController").GetComponent<BombSpawnAndExplode_cfd>();
		pc = GetComponent<PlayerController> ();
	}


	void OnTriggerEnter(Collider collider){

		if(collider.tag=="power_up_increase_blast"){
			Destroy(collider.gameObject);
			bsae.explosionSpread++;
			//DO SOME ANIMATION STUFF
			music.Play ();
			Debug.Log ("Power picked up");
		}

		if (collider.tag == "power_up_increase_speed") {
			Destroy (collider.gameObject);
			pc.speed = pc.speed * speed_increase_factor;
			music.Play ();
			Debug.Log ("Power picked up");
		}
	}
}
