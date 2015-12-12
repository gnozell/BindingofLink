using UnityEngine;
using System.Collections;

public class baseEnemy : MonoBehaviour
{

    public string playerName = "player";
    public float startingHealth = 3;
	public Color tint = Color.white;
	public float injuredTime = 1f;

    protected GameObject player;

    protected bool invulnerable;
    protected bool poisoned;
    protected bool slowed;
    protected bool frozen;
    protected bool burned;

	protected float health;

	protected float injured_timer = 0;

    // Use this for initialization
    public virtual void Start()
    {
		health = startingHealth;
        player = GameObject.Find(playerName);
		GetComponent<SpriteRenderer> ().color = tint;

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
	
	public void takeDamage(float dmg){
		// damage is taken in .5's and will round down the number entered
		health -= (dmg - (dmg % .5f));
		injured_timer = injuredTime;
		
	}
	
	public void giveHealth(float hp){
		// health is given in .5's and will round down the number entered
		health += (hp - (hp % .5f));
	}

	void OnCollisionStay2D (Collision2D other) {
		if(other.gameObject.tag == "Player"){
			other.gameObject.GetComponent<PlayerItems>().takeDamage(1);
		}
	}

    public virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        if (isDead())
        {
            OnDeath();
        }

		// enemy flashes red and normal when it takes damage
		if (injured_timer >= 0) {
			if(GetComponent<SpriteRenderer> ().color == Color.white){
				GetComponent<SpriteRenderer> ().color = Color.red;
			}
			else if(GetComponent<SpriteRenderer> ().color == Color.red){
				GetComponent<SpriteRenderer> ().color = Color.white;
			}

		} else {
			if(GetComponent<SpriteRenderer> ().color == Color.red){
				GetComponent<SpriteRenderer> ().color = Color.white;
			}
		}
		
		injured_timer -= Time.deltaTime;

    }
}
