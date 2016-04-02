using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StageDirectorController : MonoBehaviour {

	public GameObject Player;
	public GameObject MainCamera;

	private List<Vector2> locationsVisited;


	// Use this for initialization
	void Start () {
		locationsVisited = new List<Vector2> ();
	}
	
	// Update is called once per frame
	void Update () {

		// finds players location in relation to the camera
		Vector3 pos = Camera.main.WorldToViewportPoint (Player.transform.position);

		// finds the height and width of the camera given orthographicSize and aspect
		float cameraChangeVert = 2f * Camera.main.orthographicSize;
		float cameraChangeHor = cameraChangeVert * Camera.main.aspect;

		// moves the camera if the players moves out of sight (of pos.x or pos.y is less then 0 or more then 1)
		if(pos.x < 0){
			MainCamera.transform.position = new Vector3(Mathf.Lerp(MainCamera.transform.position.x, MainCamera.transform.position.x - cameraChangeHor, 100000), MainCamera.transform.position.y, MainCamera.transform.position.z);
		}
		else if (pos.x > 1 ){
			MainCamera.transform.position = new Vector3(Mathf.Lerp(MainCamera.transform.position.x, MainCamera.transform.position.x + cameraChangeHor, 100000), MainCamera.transform.position.y, MainCamera.transform.position.z);
		}
		else if (pos.y < 0){
			MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, Mathf.Lerp(MainCamera.transform.position.y, MainCamera.transform.position.y - cameraChangeVert, 100000), MainCamera.transform.position.z);
		}
		else if (pos.y > 1){
			MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, Mathf.Lerp(MainCamera.transform.position.y, MainCamera.transform.position.y + cameraChangeVert, 100000), MainCamera.transform.position.z);
		}

		if (!locationsVisited.Contains (MainCamera.transform.position)) {
			Vector2 spawnLocation = MainCamera.transform.position;
			//GameObject coin = (GameObject) Resources.Load("Prefabs/Items/dime");
			GameObject coin = (GameObject) Resources.Load("Prefabs/Map/Rooms/Room 01");
			GameObject spawned = (GameObject)  Instantiate(coin, spawnLocation, Quaternion.identity);

			locationsVisited.Add(spawnLocation);

		}


	}
}
