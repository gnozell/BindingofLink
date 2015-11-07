using UnityEngine;
using System.Collections;

public class baseEnemy: MonoBehaviour {

    public GameObject player;

    private bool invulnerable;
    private bool poisoned;

    private float health;

    // Use this for initialization
    void Start () {
	
	}

    void OnCollisionEnter2D(Collision2D other){

    }

    void OnCollisionStay2D(Collision2D other){

    }

	// Update is called once per frame
	void Update () {
	
	}
}
