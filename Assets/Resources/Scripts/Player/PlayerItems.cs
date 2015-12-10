using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerItems : MonoBehaviour {
	// Player items
	public int startKeys = 0;
	public int startCoins = 0;
	public int startBombs = 1;
	public float startHealth = 3;

	public Text coinCounter;
	public Text bombsCounter;
	public Text keysCounter;

	public GameObject heart_panel;

	private int keys;
	private int coins;
	private int bombs;
	private float health;
	private float health_container;

	public float invulnerable_length = 1.5f;
	private float invulnerable_time;
	private bool invulnerable;

	public void FixedUpdate(){
		if (invulnerable_time >= 0) {
			invulnerable = true;
			if(GetComponent<SpriteRenderer> ().color == Color.white){
				GetComponent<SpriteRenderer> ().color = Color.red;
			}
			else if(GetComponent<SpriteRenderer> ().color == Color.red){
				GetComponent<SpriteRenderer> ().color = Color.white;
			}


		} else {
			invulnerable = false;
			GetComponent<SpriteRenderer> ().color = Color.white;
		}

		invulnerable_time -= Time.deltaTime;

	}

	public void Start(){
		keys = startKeys;
		coins = startCoins;
		bombs = startBombs;
		health = startHealth;
		health_container = startHealth;
		

		if (keys > 99){
			keys = 99;
		}
		if (coins > 99){
			coins = 99;
		}
		if (bombs > 99){
			bombs = 99;
		}

		if ((keys < 10) & (keysCounter != null)) {
			keysCounter.text = "0" + keys.ToString();
			
		} else if(keysCounter != null){
			keysCounter.text = keys.ToString();
		}

		if ((coins < 10) & (coinCounter != null)) {
			coinCounter.text = "0" + coins.ToString();
			
		} else if(coinCounter != null){
			coinCounter.text = coins.ToString();
		}

		if ((bombs < 10) & (bombsCounter != null)) {
			bombsCounter.text = "0" + bombs.ToString();
			
		} else if(bombsCounter != null){
			bombsCounter.text = bombs.ToString();
		}

		for (int heart_coun = 1; heart_coun < 17; heart_coun ++) {
			RectTransform heart = (RectTransform) heart_panel.transform.FindChild("heart" + heart_coun.ToString());
			heart.GetComponent<Image>().enabled = false;
		}

		//*


		for (int heart_counter = 1; heart_counter <= health_container; heart_counter ++) {
			RectTransform heart = (RectTransform) heart_panel.transform.FindChild("heart" + heart_counter.ToString());
			heart.GetComponent<Image>().enabled = true;
			//Debug.Log ();
		} 

		//*/

	}

	//=========

	public void useKey(){
		useKeys(1);	
	}
	public void useKeys(int amount){
		keys -= amount;	
		if ((keys < 10) & (keysCounter != null)) {
			keysCounter.text = "0" + keys.ToString();
			
		} else if(keysCounter != null){
			keysCounter.text = keys.ToString();
		}
	}
	
	public int getKeys(){
		return keys;
	}
	
	public void addKeys(int amount){
		keys += amount;
		if (keys > 99){
			keys = 99;
		}
		if ((keys < 10) & (keysCounter != null)) {
			keysCounter.text = "0" + keys.ToString();
			
		} else if(keysCounter != null){
			keysCounter.text = keys.ToString();
		}
	}

	//============

	public bool is_invulnerable(){
		return invulnerable;
	}

	public void make_invulnerable(){
		invulnerable_time = invulnerable_length;
	}


	public bool isDead(){
		if (health <= 0) {
			return true;
		}
		return false;
	}

	public float getHealth(){
		return health;
	}

	public bool willKill(float dmg){
		if((health - (dmg - (dmg % .5f)) <= 0)){
			return true;
		}
		return false;
	}

	public bool willHeal(float hp){
		if(health < health_container){
			return true;
		}
		return false;
	}

	public void takeDamage(float dmg, bool truedmg=false){
		// damage is taken in .5's and will round down the number entered
		if ((!invulnerable) | truedmg) {
			health -= (dmg - (dmg % .5f));
			make_invulnerable ();
			for (float heart_counter = health + 1; heart_counter <= health_container; heart_counter ++) {
				RectTransform heart = (RectTransform)heart_panel.transform.FindChild ("heart" + heart_counter.ToString ());
				heart.GetComponent<Image> ().color = Color.black;
			} 
		}

	}



	public void giveHealth(float hp){
		// health is given in .5's and will round down the number entered
		health += (hp - (hp % .5f));
		if (health > health_container) {
			health = health_container;
		}

		for (float heart_counter = 1; heart_counter <= health; heart_counter ++) {
			RectTransform heart = (RectTransform) heart_panel.transform.FindChild("heart" + heart_counter.ToString());
			heart.GetComponent<Image>().color = Color.white;
		} 
	}

	//=========

	public void useCoin(){
		useCoins(1);	
	}

	public void useCoins(int amount){
		coins -= amount;
		if ((coins < 10) & (coinCounter != null)) {
			coinCounter.text = "0" + coins.ToString();
			
		} else if(coinCounter != null){
			coinCounter.text = coins.ToString();
		}
	}
	
	public int getCoins(){
		return coins;
	}
	
	public void addCoins(int amount){
		coins += amount;
		if (coins > 99){
			coins = 99;
		}
		if ((coins < 10) & (coinCounter != null)) {
			coinCounter.text = "0" + coins.ToString();
			
		} else if(coinCounter != null){
			coinCounter.text = coins.ToString();
		}
	}

	//==========
	public void useBomb(){
		useBombs(1);	
	}
	
	public void useBombs(int amount){
		bombs -= amount;
		if ((bombs < 10) & (bombsCounter != null)) {
			bombsCounter.text = "0" + bombs.ToString();
			
		} else if(bombsCounter != null){
			bombsCounter.text = bombs.ToString();
		}
	}
	
	public int getBombs(){
		return bombs;
	}
	
	public void addBombs(int amount){
		bombs += amount;
		if (bombs > 99){
			bombs = 99;
		}
		if ((bombs < 10) & (bombsCounter != null)) {
			bombsCounter.text = "0" + bombs.ToString();
			
		} else if(bombsCounter != null){
			bombsCounter.text = bombs.ToString();
		}
	}

}
