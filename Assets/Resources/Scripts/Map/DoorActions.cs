using UnityEngine;
using System.Collections;

public class DoorActions : MonoBehaviour {

	public string message;

	private string m_Name;
	private MapController m_Controller;

	// Use this for initialization
	void Start () {
		m_Controller = GameObject.FindGameObjectWithTag ("Map Controller").GetComponent<MapController> ();
		m_Name = gameObject.name.Split ( new string[]{ "Door " }, System.StringSplitOptions.None )[1];
		m_Name = m_Name.Split ( new string[]{ "(Clone)" }, System.StringSplitOptions.None )[0];
	}

	void Update() {
		CheckName ();
	}

	void CheckName() {
		if (m_Name == null) {
			m_Name = gameObject.name.Split ( new string[]{ "Door " }, System.StringSplitOptions.None )[1];
			m_Name = m_Name.Split ( new string[]{ "(Clone)" }, System.StringSplitOptions.None )[0];
		}
	}

	public void ChangeState() {
		if (m_Controller == null) {
			//m_Controller = GameObject.FindGameObjectWithTag ("Map Controller").GetComponent<MapController> ();
		}

		CheckName ();

		// Get the door's current state
		if (gameObject.name.Contains ("Locked")) {
			// Open door 
			//GameObject newDoor = (GameObject) Instantiate(m_Controller.MapTiles["Open Door " + m_Name], gameObject.transform.position, gameObject.transform.rotation);
			//newDoor.transform.SetParent(gameObject.transform.parent);

			// Create a new room


			// Destroy current object
			Destroy(gameObject);
		} else if(gameObject.name.Contains("Open")) {
			// Close door
			//GameObject newDoor = (GameObject) Instantiate(m_Controller.MapTiles["Locked Door " + m_Name], gameObject.transform.position, gameObject.transform.rotation);
			//newDoor.transform.SetParent(gameObject.transform.parent);

			// Destroy current object
			Destroy(gameObject);
		}
	}
}
