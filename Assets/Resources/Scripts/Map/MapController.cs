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

	List<GameObject> GetNeighbors(Vector3 pos) {
		List<GameObject> list = new List<GameObject>();
		GameObject temp;
		
		if(temp = GetRoom(pos + new Vector3(0, 9, 0))) { list.Add(temp); }
		if(temp = GetRoom(pos + new Vector3(0, -9, 0))) { list.Add(temp); }
		if(temp = GetRoom(pos + new Vector3(15, 0, 0))) { list.Add(temp); }
		if(temp = GetRoom(pos + new Vector3(-15, 0, 0))) { list.Add(temp); }
		
		return list;
	}
	
	// Returns the room at pos, or null if there is none there
	GameObject GetRoom(Vector3 pos) {
		GameObject[] rooms = GameObject.FindGameObjectsWithTag ("Room");
		
		foreach (GameObject obj in rooms) {
			if(pos.x == obj.transform.position.x &&
			   pos.y == obj.transform.position.y)
				return obj;
		}
		
		return null;
	}
}
