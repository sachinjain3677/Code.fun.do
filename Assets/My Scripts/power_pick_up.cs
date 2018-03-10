using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class power_pick_up : MonoBehaviour {

	BombSpawnAndExplode_cfd bsae;
	PlayerController pc;
	randomLevelMaker_cfd rlm;
	score_counter sc;

	int starsPickedUp;

	public AudioSource music;
	public GameObject gameOvermenu;
	public float speed_increase_factor;

	void Start(){
		gameOvermenu.SetActive (false);
		rlm = GameObject.Find ("GameController").GetComponent<randomLevelMaker_cfd> ();
		starsPickedUp = 0;
		bsae = GameObject.Find("GameController").GetComponent<BombSpawnAndExplode_cfd>();
		pc = GetComponent<PlayerController> ();
		sc = GameObject.Find ("GameController").GetComponent<score_counter> ();
	}


	void OnTriggerEnter(Collider collider){

		if(collider.tag=="power_up_increase_blast"){
			Destroy(collider.gameObject);
			bsae.explosionSpread++;
			rlm.power_ups_count--;
			//rlm.set_count_canvas ();
			music.Play ();
			Debug.Log ("Power picked up");
			sc.net_score += sc.points_powerUp;
		}

		if (collider.tag == "power_up_increase_speed") {
			Destroy (collider.gameObject);
			pc.speed = pc.speed * speed_increase_factor;
			rlm.power_ups_count--;
			//rlm.set_count_canvas ();
			music.Play ();
			Debug.Log ("Power picked up");
			sc.net_score += sc.points_powerUp;
		}

		if (collider.tag == "star_cube") {
			Destroy (collider.gameObject);
			starsPickedUp++;
			rlm.star_cubes_count--;
			//rlm.set_count_canvas ();
			music.Play ();
			sc.net_score += sc.points_winningStar;

			if (rlm.star_cubes_count == 0) {
				Debug.Log ("reached here");
				gameOvermenu.SetActive (true);
				Debug.Log("Game won!!!");
			}
		}
	}
}
