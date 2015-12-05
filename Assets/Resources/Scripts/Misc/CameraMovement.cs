using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	public string dir;
	public string expectedDir;

	private GameObject Player;
	private GameObject MapController;

	// Use this for initialization
	void Start () {
		dir = "no";
		Player = GameObject.FindGameObjectWithTag ("Player");
		MapController = GameObject.FindGameObjectWithTag ("Map Controller");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Camera.main.WorldToViewportPoint (Player.transform.position);

		// Find out expected direction
		if (pos.x < 0.3f) { expectedDir = "Left"; }
		else if (pos.x > 0.7f) { expectedDir = "Right"; }
		else if (pos.y < 0.3f) { expectedDir = "Bottom"; }
		else if (pos.y > 0.7f) { expectedDir = "Top"; }

		// If player goes left
		if (pos.x <= 0f) {
			// Give player a nudge to avoid problems
			//Player.transform.position = new Vector3(Player.transform.position.x - 2.5f, Player.transform.position.y, Player.transform.position.z);

			// Add RoomCreate to MapController
			dir = "Right";
			transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x - 15, 100000), transform.position.y, transform.position.z);
			MapController.AddComponent<RoomCreate>();
		}
		
		// If player goes right
		if (1f <= pos.x) {
			// Give player a nudge to avoid problems
			//Player.transform.position = new Vector3(Player.transform.position.x + 2.5f, Player.transform.position.y, Player.transform.position.z);
			
			// Add RoomCreate to MapController
			dir = "Left";
			transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + 15, 100000), transform.position.y, transform.position.z);
			MapController.AddComponent<RoomCreate>();
		}
		
		// If player goes down
		if (pos.y <= 0f) {
			// Give player a nudge to avoid problems
			//Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 3f, Player.transform.position.z);
			
			// Add RoomCreate to MapController
			dir = "Top";
			transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y - 9, 100000), transform.position.z);
			MapController.AddComponent<RoomCreate>();
		}
		
		// If player goes up
		if (1f <= pos.y) {
			// Give player a nudge to avoid problems
			//Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 3f, Player.transform.position.z);
			
			// Add RoomCreate to MapController
			dir = "Bottom";
			transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y + 9, 100000), transform.position.z);
			MapController.AddComponent<RoomCreate>();
		}
	}
}
