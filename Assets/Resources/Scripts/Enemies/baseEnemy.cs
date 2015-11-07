﻿using UnityEngine;
using System.Collections;

public class baseEnemy: MonoBehaviour {

    public string playerName = "link_0";
    public float health = 3;

    protected GameObject player;

    protected bool invulnerable;
    protected bool poisoned;
    protected bool slowed;
    protected bool frozen;
    protected bool burned;

    // Use this for initialization
    public virtual void Start () {
        player = GameObject.Find(playerName);

    }

    public virtual void OnDeath() {
        Destroy(gameObject);
    }

	// Update is called once per frame
	public virtual void FixedUpdate() {
        if (health <= 0) {
            OnDeath();
        }
	
	}
}