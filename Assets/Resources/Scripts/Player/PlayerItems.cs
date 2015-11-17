using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerItems : MonoBehaviour {
	// Player items
	public int startKeys = 0;
	public int startCoins = 0;
	public int startBombs = 1;

	public Text coinCounter;
	public Text bombsCounter;
	public Text keysCounter;

	private int keys;
	private int coins;
	private int bombs;

	public void Start(){
		keys = startKeys;
		coins = startCoins;
		bombs = startBombs;

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
