using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_counter : MonoBehaviour {

	public int points_sec;
	public int points_emptyBox;
	public int points_powerBox;
	public int points_enemyBox;
	public int points_starBox;
	public int points_powerUp;
	public int points_winningStar;
	public int points_enemyKill;
	public int points_death;
	public int net_score;

	public Text score_text_running;
	public Text score_text_end;

	// Use this for initialization
	void Start () {
		score_text_running.text = "SCORE: 0";
		score_text_end.text = "SCORE: 0";
	}
	
	// Update is called once per frame
	void Update () {
		score_text_running.text = "SCORE: " + net_score;
		score_text_end.text = "SCORE: " + net_score;
		//Debug.Log("net_score" + net_score);
	}
}
