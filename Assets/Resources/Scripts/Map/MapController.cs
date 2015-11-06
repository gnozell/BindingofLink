using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour {

	[HideInInspector]
	public Dictionary<string, GameObject> MapTiles;

	// Use this for initialization
	void Start () {
		MapTiles = new Dictionary<string, GameObject>();

		// Get all prefabs
		foreach(GameObject obj in Resources.LoadAll<GameObject>("Prefabs/Map")) {
			MapTiles.Add(obj.name, obj);
		}
	}
}
