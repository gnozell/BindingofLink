using UnityEngine;
using System.Collections;

public class PlayerActions : MonoBehaviour {

	private PlayerItems m_Items;

	void Start() {
		m_Items = GetComponent<PlayerItems> ();
	}

	void OnTriggerStay2D(Collider2D other) {
		// If action key is pressed
		if (Input.GetButtonDown ("Action")) {
			// If colliding with a door
			if (other.gameObject.CompareTag ("Door") && m_Items.Keys > 0) {
				// Open door door
				other.gameObject.GetComponent<DoorActions>().ChangeState();

				// Take away a key
				m_Items.Keys--;
			}
		}
	}
}
