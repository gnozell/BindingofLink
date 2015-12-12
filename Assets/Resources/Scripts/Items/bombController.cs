using UnityEngine;
using System.Collections;

public class bombController : MonoBehaviour {

	public float lifeTime = 3f;

	private ArrayList touching = new ArrayList();


	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeTime);
	}

	void OnDestroy () {
		for(int count = 0; count < touching.Count; count++ ){

			if ((touching[count] != null)&(touching[count] is Collider2D)){
				Collider2D temp = (Collider2D) touching[count];

				Vector2 blowback = (temp.transform.position - this.transform.position);
			

				if(temp.tag == "Player"){
					temp.GetComponent<PlayerItems>().takeDamage(1);
				}

				else if(temp.tag == "Enemy"){
					temp.GetComponent<baseEnemy>().takeDamage(1);
				}

				else if(temp.tag == "Droppable"){
					//temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 10)*50);
				}

				if(temp.GetComponent<Rigidbody2D>() != null){
					temp.GetComponent<Rigidbody2D>().AddForce(blowback*700);
				}

			}
		}
	}

	void OnTriggerStay2D (Collider2D other) {
		// checks if is currently tracking other
		// if not add it to its list

		if (!touching.Contains (other)) {
			touching.Add(other);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		// checks if is currently tracking other
		// if it is remove from its list
		if (touching.Contains (other)) {
			touching.Remove(other);
		}
	}
}
