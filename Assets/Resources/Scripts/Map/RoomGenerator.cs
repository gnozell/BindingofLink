using UnityEngine;
using System.Collections;

public class RoomGenerator : MonoBehaviour {

	public bool RandomSize = false;
	// Number of floor tiles, not including walls
	public Vector2 RoomSize = new Vector2(10f, 10f);

	private GameObject RoomParent;
	public Object[] MapTiles;


	// Use this for initialization
	void Start () {
		// Create empty for map tiles
		RoomParent = new GameObject ();
		RoomParent.name = "Room Tiles";

		LoadPrefabs (ref MapTiles, "Map");
		CreateRoom ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void LoadPrefabs(ref Object[] Container, string Folder) {
		Container = (Object[]) Resources.LoadAll ("Prefabs/" + Folder + "/");
	}

	void CreateRoom() {
		GameObject FloorTile = FindObjectWithName (MapTiles, "Floor Tile (1x1)");
		
		// Create floor
		for (int i = 0; i < RoomSize.x; i++) {
			for(int j = 0; j < RoomSize.y; j++) {
				GameObject clone = Instantiate(FloorTile);
				clone.transform.position = new Vector3(j, -i, 0);
				clone.transform.SetParent(RoomParent.transform);
			}
		}

		// Create corners 0 = TL, 1 = TR, 2 = BL, 3 = BR
		GameObject[] Corners = new GameObject[4];
		Corners [0] = FindObjectWithName (MapTiles, "Top Left Corner");
		Corners [1] = FindObjectWithName (MapTiles, "Top Right Corner");
		Corners [2] = FindObjectWithName (MapTiles, "Bottom Left Corner");
		Corners [3] = FindObjectWithName (MapTiles, "Bottom Right Corner");

		for (int i = 0; i < Corners.Length; i++) {
			GameObject corner;
			Vector3 pos = new Vector3(0, 0, 0);

			if( i == 0 )
				pos = new Vector3(-2, 2, 0);
			else if(i == 1)
				pos = new Vector3(RoomSize.x, 2, 0);
			else if(i == 2)
				pos = new Vector3(-2, -RoomSize.y, 0);
			else if(i == 3)
				pos = new Vector3(RoomSize.x, -RoomSize.y, 0);

			corner = Instantiate(Corners[i]);
			corner.transform.position = pos;
			//corner.transform.SetParent(RoomParent.transform);
		}

	}

	GameObject FindObjectWithName(Object[] array, string name) {
		for (int i = 0; i < array.Length; i++) {
			if(array[i].name == name)
				return (GameObject) array[i];
		}
		// If not found, return empty
		GameObject retn = new GameObject ();
		return retn;
	}
}
