using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomCreate : MonoBehaviour {

	public Vector3 position;

	void Start() {
		position = Camera.main.transform.position;

		// Create a new room
		if (!CheckPosition (position)) {
			// Create new room
			GameObject newRoom = (GameObject) Instantiate(Resources.Load<GameObject>("Prefabs/Map/Rooms/Room 01"), position, new Quaternion(0, 0, 0, 0));

			// Find which door to open
			newRoom.transform.FindChild("Doors").FindChild("Locked Door " + Camera.main.gameObject.GetComponent<CameraMovement>().dir).GetComponent<DoorActions>().ChangeState();
		} else {
			//Debug.Log("There's a room here already");
		}

		// Destroy when done
		Destroy (this);
	}

	// Returns true if there is a room at pos
	bool CheckPosition(Vector3 pos) {
		GameObject[] rooms = GameObject.FindGameObjectsWithTag ("Room");

		foreach (GameObject obj in rooms) {
			if(pos.x == obj.transform.position.x &&
			   pos.y == obj.transform.position.y)
				return true;
		}

		return false;
	}
}
