using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 40f;

	public Canvas pauseMenu;

	private Rigidbody2D playerRb2D;
	private Animator playerAnim;
	private PlayerItems m_Items;



	private bool is_paused = false;



	void Start(){
		m_Items = GetComponent<PlayerItems> ();
		playerRb2D = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Pause")){
			is_paused = !is_paused;
			if (is_paused) {
				pauseMenu.GetComponent<UIController>().pause();
			} else {
				pauseMenu.GetComponent<UIController>().unpause();
			}
		}




		//Debug.Log (paused);


		float hor = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");

		float attack_hor = Input.GetAxis ("Fire Horizontal");
		float attack_vert = Input.GetAxis ("Fire Vertical");

		if (m_Items.isDead ()) {
			// if you are dead you can't do shit sorry buddy
			playerRb2D.velocity = new Vector3 (0f, 0f, 0f);
			playerAnim.Play("link_death");

		} else if ((attack_hor != 0)|(attack_vert != 0)){
			//causes player to attack
			playerRb2D.AddForce(new Vector2(hor, vert) * (speed/4));
			playerAnim.SetBool ("idle", false);
			playerAnim.SetBool ("going_down", false);
			playerAnim.SetBool ("going_left", false);
			playerAnim.SetBool ("going_right", false);
			playerAnim.SetBool ("idle", false);
			playerAnim.SetBool ("attacking", true);

			if(attack_hor > 0){
				if(!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("player_attack_right")){
					playerAnim.Play("player_attack_right");
				}
			} else if (attack_hor < 0){
				if(!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("player_attack_left")){
					playerAnim.Play("player_attack_left");
				}
			} else if (attack_vert > 0) {
				if(!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("player_attack_up")){
					playerAnim.Play("player_attack_up");
				}
			} else if (attack_vert < 0){
				if(!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("player_attack_down")){
					playerAnim.Play("player_attack_down");
				}
			}

		} else {
			//This moves him
			playerAnim.SetBool ("attacking", false);
			playerRb2D.AddForce(new Vector2(hor*speed, vert*speed));

			// sets his animation
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
