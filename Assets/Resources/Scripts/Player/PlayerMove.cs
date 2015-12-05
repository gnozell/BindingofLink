using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 10f;

	private Rigidbody2D playerRb2D;
	private Animator playerAnim;
	private PlayerItems m_Items;


	void Start(){
		m_Items = GetComponent<PlayerItems> ();
		playerRb2D = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (m_Items.isDead ()) {
			playerRb2D.velocity = new Vector3 (0f, 0f, 0f);
			playerAnim.Play("link_death");
		} else {

			float hor = Input.GetAxis ("Horizontal");
			float vert = Input.GetAxis ("Vertical");

			//Debug.Log ("hor: " + hor + " vert: " + vert);
			playerRb2D.velocity = new Vector3 (hor, vert, 0f) * speed;


			if (hor == 0 && vert == 0) {
				playerAnim.SetBool ("going_up", false);
				playerAnim.SetBool ("going_down", false);
				playerAnim.SetBool ("going_left", false);
				playerAnim.SetBool ("going_right", false);
				playerAnim.SetBool ("idle", true);
			}

			if (vert < 0) {
				playerAnim.SetBool ("going_up", false);
				playerAnim.SetBool ("going_down", true);
				playerAnim.SetBool ("going_left", false);
				playerAnim.SetBool ("going_right", false);
				playerAnim.SetBool ("idle", false);
			} else if (vert > 0) {
				playerAnim.SetBool ("going_up", true);
				playerAnim.SetBool ("going_down", false);
				playerAnim.SetBool ("going_left", false);
				playerAnim.SetBool ("going_right", false);
				playerAnim.SetBool ("idle", false);
			}

			if (hor < 0) {
				playerAnim.SetBool ("going_up", false);
				playerAnim.SetBool ("going_down", false);
				playerAnim.SetBool ("going_left", true);
				playerAnim.SetBool ("going_right", false);
				playerAnim.SetBool ("idle", false);
			} else if (hor > 0) {
				playerAnim.SetBool ("going_up", false);
				playerAnim.SetBool ("going_down", false);
				playerAnim.SetBool ("going_left", false);
				playerAnim.SetBool ("going_right", true);
				playerAnim.SetBool ("idle", false);
			}
		}

	}
}
