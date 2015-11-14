﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 10f;

	private Rigidbody2D playerRb2D;
	private Animator playerAnim;


	void Start(){
		playerRb2D = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float hor = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");

		Debug.Log ("hor: " + hor + " vert: " + vert);
		playerRb2D.velocity = new Vector3 (hor, vert, 0f) * speed;


		if (hor == 0 && vert == 0) {
			playerAnim.SetBool ("going_up", false);
			playerAnim.SetBool ("going_down", false);
			playerAnim.SetBool ("going_left", false);
			playerAnim.SetBool ("going_right", false);
			playerAnim.SetBool ("idle", true);
		}

		if (hor < 0) {
			playerAnim.SetBool ("going_left", true);
			playerAnim.SetBool ("idle", false);
		} else if (hor > 0) {
			playerAnim.SetBool ("going_right", true);
			playerAnim.SetBool ("idle", false);
		}

		if (vert < 0) {
			playerAnim.SetBool ("going_down", true);
			playerAnim.SetBool ("idle", false);
		} else if (vert > 0) {
			playerAnim.SetBool ("going_up", true);
			playerAnim.SetBool ("idle", false);
		}

	}
}
