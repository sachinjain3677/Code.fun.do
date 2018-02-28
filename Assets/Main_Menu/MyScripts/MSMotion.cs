using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSMotion : MonoBehaviour {
	Animator Anim;

	// Use this for initialization
	void Start () {
		
        //transform.localScale = new Vector3(0.24f,0.24f,0.24f);
		//	Anim.SetBool ("isBack", true);
		//	Anim.SetBool ("isFwd", true);
	}

	// Update is called once per frame
	void Update () {
        //transform.localScale = new Vector3(0.14f, 0.14f, 0.14f);

        Anim = GetComponent<Animator>();
        Anim.SetBool("isAssembled", true);
    }

	public  void MoveFwd()
	{
		Anim.SetBool ("isFwd", true);
		Anim.SetBool ("isBack", false);
		Anim.SetBool ("isRight", false);
		Anim.SetBool ("isLeft", false);
		transform.Translate(-Vector3.up * Time.deltaTime*2);


	}
	public  void MoveBack()
	{
		Anim.SetBool ("isFwd", false);
		Anim.SetBool ("isBack", true);
		Anim.SetBool ("isRight", false);
		Anim.SetBool ("isLeft", false);
		Debug.Log ("in Back Mode");
		transform.Translate(Vector3.up * Time.deltaTime*2);

	}
	public  void Right()
	{
		Anim.SetBool ("isFwd", false);
		Anim.SetBool ("isBack", false);
		Anim.SetBool ("isRight", true);
		Anim.SetBool ("isLeft", false);
		transform.Rotate (0,0,1f);

	}
	public  void Left()
	{
		Anim.SetBool ("isFwd", false);
		Anim.SetBool ("isBack", false);
		Anim.SetBool ("isRight", false);
		Anim.SetBool ("isLeft", true);
		transform.Rotate (0,0,-1f);

	}
	public  void Idle()
	{
		Debug.Log ("in Idle ##########");
		// if state is idle ... dont repeat...
		Anim.SetBool ("isFwd", false);
		Anim.SetBool ("isBack", false);
		Anim.SetBool ("isRight", false);
		Anim.SetBool ("isLeft", false);


	}
}
