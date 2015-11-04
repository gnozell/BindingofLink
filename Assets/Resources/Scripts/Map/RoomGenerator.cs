using UnityEngine;
using System.Collections;

public class RoomGenerator : MonoBehaviour
{
	
	public bool RandomSize = false;
	public int RandomSeed = 33;
	public int RandomMin = 3, RandomMax = 25;

	// Number of floor tiles, not including walls
	public Vector2 RoomSize = new Vector2 (10f, 10f);
	public Object[] MapTiles;
	
	// Use this for initialization
	void Start ()
	{

		// Creates a random sized room
		if (RandomSize) {
			RoomSize = new Vector2 ((int)Random.Range (RandomMin, RandomMax), (int)Random.Range (RandomMin, RandomMax));
		}

		// Load Map prefabs
		LoadResources (ref MapTiles, "Prefabs/Map");

		CreateRoom ();
	}
	
	// Creates a room
	void CreateRoom() {
		// Create parent for entire room
		GameObject RoomParent = new GameObject ();
		RoomParent.name = "Room";
		
		// Create parent for floor tiles
		GameObject FloorParent = new GameObject ();
		FloorParent.name = "Floor";
		FloorParent.transform.SetParent (RoomParent.transform);

		// Create parent for walls
		GameObject WallsParent = new GameObject ();
		WallsParent.name = "Walls";
		WallsParent.transform.SetParent (RoomParent.transform);
		GameObject CornersParent = new GameObject ();
		CornersParent.name = "Corners";
		CornersParent.transform.SetParent (WallsParent.transform);
		GameObject TopWalls = new GameObject ();
		TopWalls.name = "Top Walls";
		TopWalls.transform.SetParent (WallsParent.transform);
		GameObject LeftWalls = new GameObject ();
		LeftWalls.name = "Left Walls";
		LeftWalls.transform.SetParent (WallsParent.transform);
		GameObject RightWalls = new GameObject ();
		RightWalls.name = "Right Walls";
		RightWalls.transform.SetParent (WallsParent.transform);
		GameObject BottomWalls = new GameObject ();
		BottomWalls.name = "Bottom Walls";
		BottomWalls.transform.SetParent (WallsParent.transform);

		// Create parent for doors
		GameObject DoorsParent = new GameObject ();
		DoorsParent.name = "Doors";
		DoorsParent.transform.SetParent (RoomParent.transform);

		// Random Door position
		bool SpawnDoor;
		if(Random.value > 0.5) { SpawnDoor = true; }
		else { SpawnDoor = false; }

		int DoorWall = (int)Random.Range (0, 4);
		Vector2 DoorPosition = new Vector2((int) Random.Range(0, RoomSize.x - 3), (int) Random.Range(0, RoomSize.y - 3));


		for (int i = 0; i < RoomSize.x; i++) {
			for(int j = 0; j < RoomSize.y; j++) {
				// If corner
				if(i == 0 && j == 0)
					CreateTile(FindObjectWithName(MapTiles, "Top Left Corner"), new Vector3(-2, 2, 0), CornersParent);
				if(i == RoomSize.x - 1 && j == 0)
					CreateTile(FindObjectWithName(MapTiles, "Top Right Corner"), new Vector3(RoomSize.x, 2, 0), CornersParent);
				if(i == 0 && j == RoomSize.y - 1)
					CreateTile(FindObjectWithName(MapTiles, "Bottom Left Corner"), new Vector3(-2, -RoomSize.y, 0), CornersParent);
				if(i == RoomSize.x - 1 && j == RoomSize.y - 1)
					CreateTile(FindObjectWithName(MapTiles, "Bottom Right Corner"), new Vector3(RoomSize.x, -RoomSize.y, 0), CornersParent);

				// Create Doors
				// Find out how to delete walls
				if(true) {
					if(DoorWall == 0 && j == 0) {
						// Door is on top wall
						if( i == DoorPosition.x) {
							CreateTile(FindObjectWithName(MapTiles, "Locked Door Top"), new Vector3(i, 2, 0), DoorsParent);
							SpawnDoor = false;
						}
					}
					if(DoorWall == 1 && i == 0) {
						// Door is on left wall
						if( j == DoorPosition.y) {
							CreateTile(FindObjectWithName(MapTiles, "Locked Door Left"), new Vector3(-2, -j, 0), DoorsParent);
							SpawnDoor = false;
						}
					}
					if(DoorWall == 2 && i == RoomSize.x - 1) {
						// Door is on right wall
						if( j == DoorPosition.y) {
							CreateTile(FindObjectWithName(MapTiles, "Locked Door Right"), new Vector3(RoomSize.x, -j, 0), DoorsParent);
							SpawnDoor = false;
						}
					}
					if(DoorWall >= 3 && j == RoomSize.y - 1) {
						// Door is on bottom wall
						if( i == DoorPosition.x) {
							CreateTile(FindObjectWithName(MapTiles, "Locked Door Bottom"), new Vector3(i, -RoomSize.y, 0), DoorsParent);
							SpawnDoor = false;
						}
					}
				}

				// Create Walls
				if(j == 0)
					CreateTile(FindObjectWithName(MapTiles, "Top Wall"), new Vector3(i, 2, 0), TopWalls);
				if(i == 0)
					CreateTile(FindObjectWithName(MapTiles, "Left Wall"), new Vector3(-2, -j, 0), LeftWalls);
				if(i == RoomSize.x - 1)
					CreateTile(FindObjectWithName(MapTiles, "Right Wall"), new Vector3(RoomSize.x, -j, 0), RightWalls);
				if(j == RoomSize.y - 1)
					CreateTile(FindObjectWithName(MapTiles, "Bottom Wall"), new Vector3(i, -RoomSize.y, 0), BottomWalls);

				// Create floor tile
				CreateTile (FindObjectWithName(MapTiles, "Floor Tile (1x1)"), new Vector3(i, -j, 0), FloorParent);
			}
		}
	}

	// Create a tile
	void CreateTile(GameObject obj, Vector3 pos, GameObject parent) {
		GameObject clone = (GameObject) Instantiate (obj, pos, new Quaternion(0,0,0,0));
		clone.transform.SetParent(parent.transform);
	}

	// Loads resources into Container from inside of Folder
	void LoadResources (ref Object[] Container, string Folder) {
		Container = (Object[])Resources.LoadAll (Folder);
	}

	// Returns a GameObject with Name name from within array; If nothing is found, return empty GameObject
	GameObject FindObjectWithName (Object[] array, string name) {
		for (int i = 0; i < array.Length; i++) {
			if (array [i].name == name)
				return (GameObject)array [i];
		}
		// If not found, return empty
		GameObject retn = new GameObject ();
		return retn;
	}
}
