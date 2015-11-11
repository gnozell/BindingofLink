using UnityEngine;
using System.Collections;

public class burrow : baseEnemy {

	public float speed = 10f;

	private string state;

	private float currentTimer;

	private float waitTimer;
	private float buildingTimer;
	private float chargeTimer;
	private float dugTimer;

	private Vector3 playerPosition;
	/*
	 * The burrow has states that it can be in to determine
	 * what it will do
	 * 
	 * wait - while in wait it will just stop were it is
	 * 		 and not do anything, gives time for player to attack
	 * 
	 * building - while in this state it is "building" up speed and preparing
	 * 				to launch itself at the player
	 * 
	 * charging - launches itself at the player object
	 * 
	 * dug - digs into the ground dissapears, it relocates itself to someplace else.
	 *
	 */

	// Use this for initialization
	public override void Start () {
		base.Start ();
		state = "wait";

		waitTimer = 1f;
		buildingTimer = 2f;
		chargeTimer = 5f;
		dugTimer = 3f;

		currentTimer = waitTimer;
	
	}

	
	// Update is called once per frame
	void Update () {
		currentTimer -= Time.deltaTime;

		if (currentTimer < 0) {
			/*
			 * If the current timer is less then 0 it will change the state
			 * 
			 */
			switch (state) {

			case "wait":
				state = "dug";
				currentTimer = dugTimer;
				break;

			case "building":
				state = "charging";
				currentTimer = chargeTimer;
				if (player != null){
					playerPosition = player.transform.position;
				}

				break;

			case "charging":
				state = "wait";
				currentTimer = waitTimer;
				break;

			case "dug":
				state = "building";
				currentTimer = buildingTimer;
				break;
				
			default:
				state = "wait";
				break;
			}
		} else {
			// if the currenttimer is above or equal to 0 does the following
			Debug.Log(state);

			switch (state) {
				
			case "wait":
				break;
				
			case "building":
				break;
				
			case "charging":
				Debug.Log(playerPosition);
				Debug.Log(player);
				if (player != null){

					transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
				}
				break;
				
			case "dug":
				break;
				
			default:
				state = "wait";
				break;
			}


		}
	
	}
}
