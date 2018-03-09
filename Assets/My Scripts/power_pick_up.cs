using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_pick_up : MonoBehaviour {

	BombSpawnAndExplode_cfd bsae;
	PlayerController pc;
	randomLevelMaker_cfd rlm;

	int starsPickedUp;

	public AudioSource music;
	public GameObject winMenu;
	public float speed_increase_factor;

	void Start(){
		winMenu.SetActive (false);
		rlm = GameObject.Find ("GameController").GetComponent<randomLevelMaker_cfd> ();
		starsPickedUp = 0;
		bsae = GameObject.Find("GameController").GetComponent<BombSpawnAndExplode_cfd>();
		pc = GetComponent<PlayerController> ();
	}


	void OnTriggerEnter(Collider collider){

		if(collider.tag=="power_up_increase_blast"){
			Destroy(collider.gameObject);
			bsae.explosionSpread++;
			rlm.power_ups_count--;
			//rlm.set_count_canvas ();
			music.Play ();
			Debug.Log ("Power picked up");
		}

		if (collider.tag == "power_up_increase_speed") {
			Destroy (collider.gameObject);
			pc.speed = pc.speed * speed_increase_factor;
			rlm.power_ups_count--;
			//rlm.set_count_canvas ();
			music.Play ();
			Debug.Log ("Power picked up");
		}

		if (collider.tag == "star_cube") {
			Destroy (collider.gameObject);
			starsPickedUp++;
			rlm.star_cubes_count--;
			//rlm.set_count_canvas ();
			music.Play ();

			if (rlm.star_cubes_count == 0) {
				Debug.Log ("reached here");
				winMenu.SetActive (true);
				Debug.Log("Game won!!!");
			}
		}
	}
}
