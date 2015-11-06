using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 10f;

	// Update is called once per frame
	void FixedUpdate () {
		float hor = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");

		GetComponent<Rigidbody2D>().velocity = new Vector3 (hor, vert, 0f) * speed;
	}
}
