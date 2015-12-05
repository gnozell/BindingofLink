using UnityEngine;
using System.Collections;

public class heartController : MonoBehaviour {


	protected float heal = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D other) {
		// checks if is currently tracking other
		// if not add it to its list
		
		if (other.gameObject.tag == "Player") {
			if(other.gameObject.GetComponent<PlayerItems>().willHeal(heal)){
				other.gameObject.GetComponent<PlayerItems>().giveHealth(heal);
				Destroy(gameObject);
			}

		}
	}
}
