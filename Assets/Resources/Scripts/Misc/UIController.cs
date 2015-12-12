using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {
	
	public Canvas pauseMenu;
	private float pauseFlashTimer = 1f;
	
	// Use this for initialization
	void Start () {
		//pauseMenu = pauseMenu.GetComponent<Image> ();
		pauseMenu.enabled = false;

	}

	void Update () {
		if (pauseFlashTimer < 0) {
			pauseFlashTimer = 1f;
			Text pauseText = this.transform.Find ("pause").GetComponentInChildren<Text>();

			if(pauseText.color ==  Color.black){
				pauseText.color = Color.red;
			} else {
				pauseText.color = Color.black;
			}
		} 
		pauseFlashTimer -= Time.deltaTime;
	}

	public void pause(){
		pauseMenu.enabled = true;
	}

	public void unpause(){
		pauseMenu.enabled = false;
	}

	public bool isPaused(){
		return pauseMenu.enabled;
	}
	
}
