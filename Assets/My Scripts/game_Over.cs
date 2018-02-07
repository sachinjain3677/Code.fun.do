using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_Over : MonoBehaviour {

	BombSpawnAndExplode_cfd bsae;

	public GameObject game_over_menu;
	// Use this for initialization
	void Start () {
		bsae = GameObject.Find ("GameController").GetComponent<BombSpawnAndExplode_cfd> ();
		game_over_menu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (bsae.isDead) {
			game_over_menu.SetActive (true);
		}
	}
}
