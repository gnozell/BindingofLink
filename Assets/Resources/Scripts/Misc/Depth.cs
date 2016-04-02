using UnityEngine;
using System.Collections;

public class Depth : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		Vector3 start = gameObject.transform.position;
		gameObject.transform.position = new Vector3(start.x,start.y,start.y);
	}
}
