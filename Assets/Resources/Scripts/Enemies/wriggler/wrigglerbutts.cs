using UnityEngine;
using System.Collections;

public class wrigglerbutts : baseEnemy {

    public GameObject Leader;
    public float speed = 0.15f;

	// Use this for initialization
    public override void Start () {

    }
	
	// Update is called once per frame
	public override void FixedUpdate() {
        Vector3 spot = Leader.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, spot, speed);
    }
}
